using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace ProductManagement.MessageContracts
{
    public static class BusConfigurator
    {

        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(RabbitmqConstants.RabbitMqUri, configurator =>
                {
                    configurator.Username(RabbitmqConstants.UserName);
                    configurator.Password(RabbitmqConstants.Password);
                });

                registrationAction?.Invoke(factory);
            });
        }
    }
}