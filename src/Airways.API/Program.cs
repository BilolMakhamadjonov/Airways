using Airways.API;
using Airways.API.Filters;
using Airways.API.JobBronTicket;
using Airways.API.Middleware;
using Airways.Application.BackgroundServices;
using Airways.Application.Common.Email;
using Airways.Application.MediatR.AirlineHandle;
using Airways.Application.Models.Airline;
using Airways.Application.Services;
using Airways.DataAccess;
using Airways.DataAccess.Authentication;
using Airways.DataAccess.Persistance;
using MediatR;
using Microsoft.OpenApi.Models;
using Quartz;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(CreateAirlineCommandHandler).Assembly);

builder.Services.AddQuartz(q =>
{
    q.AddJob<DailyJob>(opts => opts.WithIdentity("dailyRabbitMqJob", "group1"));
    q.AddTrigger(opts => opts
        .ForJob("dailyRabbitMqJob", "group1")
        .WithIdentity("dailyTrigger", "group1")
        .StartNow()
        .WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever()));
});

builder.Services.AddTransient<IRequestHandler<CreateAirlineCommand, CreateAirlineResponceModel>, CreateAirlineCommandHandler>();
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

// Qolgan xizmatlar ro'yxatini qo'shish
builder.Services.AddSingleton<RabbitMqConsumer>(sp => new RabbitMqConsumer("api.All"));

builder.Services.Configure<GoogleSmtpSettings>(builder.Configuration.GetSection("GoogleSmtpSettings"));
builder.Services.AddControllers(config => config.Filters.Add(typeof(ValidateModelAttribute)));

// Redis konfiguratsiyasi
var redisOptions = new ConfigurationOptions
{
    EndPoints = { builder.Configuration.GetConnectionString("Redis").Split(',')[0] },
    AbortOnConnectFail = false,
    ConnectTimeout = 5000,
    SyncTimeout = 5000,
    ConnectRetry = 3,
    KeepAlive = 60,
    DefaultDatabase = 0
};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket API", Version = "v1" });
    c.OperationFilter<HtmlResponseOperationFilter>();
});

builder.Services.AddSwagger();
builder.Services.AddDataAccess(builder.Configuration)
   .AddApplication(builder.Environment);

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy => policy.RequireClaim("User"));
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
});

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(redisOptions));

builder.Services.AddHostedService<ScheduledBackgroundService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airways API"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<RabbitMqMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.UseMiddleware<TransactionMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddlewear>();

app.MapControllers();

app.Run();
