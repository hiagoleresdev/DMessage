using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace DMessage.Producer.Services
{
    public class QueueService
    {
        private readonly string _hostname = "localhost";
        private readonly string _userName = "dmessage";
        private readonly string _password = "dmessage123";

        public async Task PublishOrderCreatedAsync(string orderMessage)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _userName,
                Password = _password
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "orders-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var body = Encoding.UTF8.GetBytes(orderMessage);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "orders-queue",
                body: body
            );

            Console.WriteLine($"[x] Mensagem enviada com sucesso: {orderMessage}");
        }


    }
}
