using DMessage.Consumer.Service;

var consumerService = new QueueConsumerService();
var cts = new CancellationTokenSource();

Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    cts.Cancel();
    Console.WriteLine("[*] Encerrando o Consumer...");
};

await consumerService.StartConsumingAsync(cts.Token);