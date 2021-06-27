using System;
using System.Threading.Tasks;
using MassTransit;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Consumers;

namespace ProductManagement.Notification
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Notification";

            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitmqConstants.NotificationServiceQueue, endPoint =>
                {
                    endPoint.Consumer<NotificationProductRegisteredEventConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
        }
    }
}
