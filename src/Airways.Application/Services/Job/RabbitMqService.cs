using RabbitMQ.Client;
using System.Text;

namespace Airways.Application.Services.Job
{
    public class RabbitMqService
    {
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMqService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void SendMessageToQueue(string message)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "airlineQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "airlineQueue",
                                 basicProperties: null,
                                 body: body);
        }
    }


}
