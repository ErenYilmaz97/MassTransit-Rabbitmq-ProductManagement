using System;
using System.Threading.Tasks;
using MassTransit;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Consumers;

namespace ProductManagement.Registration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Registration";

            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitmqConstants.RegistrationServiceQueue, endPoint =>
                {
                    endPoint.Consumer<ProductRegistrationCommandConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
        }
    }
}
