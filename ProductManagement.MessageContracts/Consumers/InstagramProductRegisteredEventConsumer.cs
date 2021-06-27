using System;
using System.Threading.Tasks;
using MassTransit;
using ProductManagement.MessageContracts.Events;

namespace ProductManagement.MessageContracts.Consumers
{
    public class InstagramProductRegisteredEventConsumer : IConsumer<IProductRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IProductRegisteredEvent> context)
        {
            Console.WriteLine($"{context.Message.ProductName} İsimli Ürün Instagramda Yayınlandı.");
        }
    }
}