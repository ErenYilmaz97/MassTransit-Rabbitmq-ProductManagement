using System;
using System.Threading.Tasks;
using MassTransit;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Consumers;

namespace ProductManagement.Instagram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Instagram";

            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitmqConstants.InstagramServiceQueue, endPoint =>
                {
                    endPoint.Consumer<InstagramProductRegisteredEventConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
        }
    }
}
