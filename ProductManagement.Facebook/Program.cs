using System;
using System.Threading.Tasks;
using MassTransit;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Consumers;

namespace ProductManagement.Facebook
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Facebook";

            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitmqConstants.FacebookServiceQueue, endPoint =>
                {
                    endPoint.Consumer<FacebookProductRegisteredEventConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
        }
    }
}
