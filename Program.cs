// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory() {HostName = "localhost"};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("hello", false, false, false, null);

while (true)
{
    var message = Console.ReadLine();
    channel.BasicPublish("", "hello", null, Encoding.UTF8.GetBytes(message));
    Console.WriteLine($"Message Sent: {message}");
}

Console.ReadLine();