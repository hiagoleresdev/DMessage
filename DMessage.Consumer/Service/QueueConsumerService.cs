using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace DMessage.Consumer.Service
{
    public class QueueConsumerService
    {
        private readonly string _hostName = "localhost";
        private readonly string _userName = "dmessage";
        private readonly string _password = "dmessage123";

        public async Task StartConsumingAsync(CancellationToken token)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
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

            Console.WriteLine("[*] Aguardando mensagens. Pressione [Ctrl+C] para sair.");

            //Registra o Consumer
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"[x] Mensagem recebida: {message}");

                await Task.CompletedTask;
            };

            //Consome a Fila Orders Queue
            await channel.BasicConsumeAsync(
                queue: "orders-queue",
                autoAck: true,
                consumer: consumer
            );

            try
            {
                //Isso faz o Consumer rodar durante toda a execução - Só será desligado com o CTRL + C
                await Task.Delay(Timeout.Infinite, token);

            }
            catch (TaskCanceledException)
            {

            }
        }
    }
}
