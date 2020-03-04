using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureServiceBusAdmin
{
    public class Create
    {
        public static async Task Messages(string serviceBusConnectionString, string queueName)
        {    
            const int numberOfMessages = 10;
            IQueueClient queueClient = new QueueClient(serviceBusConnectionString, queueName);

            try
            {
                for (var i = 0; i < numberOfMessages; i++)
                {
                    // Create a new message to send to the queue.
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console.
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the queue.
                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            //Console.ReadKey();

            await queueClient.CloseAsync();
        }    
    }
}
