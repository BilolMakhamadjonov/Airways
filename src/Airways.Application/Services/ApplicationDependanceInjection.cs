using Airways.Application.MappingProfiles;
using Airways.Application.Services.Impl;
using Airways.Shared.services;
using Airways.Shared.services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Airways.Application.Services;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IAircraftService, AircraftService>();
        services.AddScoped<IAirlineService, AirlineService>();
        services.AddScoped<IClassService, ClasService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IPricePolicyService, PricePolicyService>();
        services.AddScoped<IReviewservice, ReviewService>();
        services.AddScoped<IReysService, ReysService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<ITemplateService, TemplateService>();

        services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }
}