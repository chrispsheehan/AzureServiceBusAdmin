using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureServiceBusAdmin
{
    class Program
    {
        const string ServiceBusConnectionString = "[SecretThings]";
        const string QueueName = "TestQueue";
        static IQueueClient queueClient;

        public static async Task Main(string[] args)
        {    
            await Create.Messages(ServiceBusConnectionString, QueueName);
        }      
    }
}
