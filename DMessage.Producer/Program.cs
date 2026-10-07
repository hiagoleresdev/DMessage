using DMessage.Producer.Services;

var queueService = new QueueService();

string message = "Pedido 123 foi criado";

await queueService.PublishOrderCreatedAsync(message);

Console.WriteLine("Pressione qualquer tecla para sair");
Console.ReadKey();