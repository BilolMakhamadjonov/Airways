using Airways.DataAccess.Persistance;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Airways.Core.Entities;
using System.Text;

public class AirlineJobService : BackgroundService
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly DatabaseContext _dbContext;

    public AirlineJobService(IConnectionFactory connectionFactory, DatabaseContext dbContext)
    {
        _connectionFactory = connectionFactory;
        _dbContext = dbContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var connection = _connectionFactory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "airlineQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        List<string> messages = new List<string>();

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            messages.Add(message);

            // 1 kun o'tgandan keyin ma'lumotni bazaga saqlash
            if (messages.Count >= 1000) // 1000 ta xabar to'plangandan so'ng yoki boshqa intervalga qarab
            {
                SaveToDatabase(messages);
                messages.Clear();
            }
        };

        channel.BasicConsume(queue: "airlineQueue", autoAck: true, consumer: consumer);

        await Task.CompletedTask;
    }

    private void SaveToDatabase(List<string> messages)
    {
        foreach (var message in messages)
        {
            // Bu yerda ma'lumotni bazaga saqlash
            _dbContext.Airlines.Add(new Airline { Message = message, Date = DateTime.UtcNow });
        }
        _dbContext.SaveChanges();
    }
}
