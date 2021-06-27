using System;
using System.Threading.Tasks;
using MassTransit;
using ProductManagement.MessageContracts.Commands;
using ProductManagement.MessageContracts.Events;
using ProductManagement.MessageContracts.Models;

namespace ProductManagement.MessageContracts.Consumers
{
    public class ProductRegistrationCommandConsumer : IConsumer<IProductRegistrationCommand>
    {
        public async Task Consume(ConsumeContext<IProductRegistrationCommand> context)
        {
            //VERİ TABANINA EKLEME KODLARI
            Console.WriteLine($"{context.Message.ProductName} isimli ürün ({context.Message.Quantity} Adet) :");
            Console.WriteLine($"Veritabanına kayıt edilmiştir.");
            Console.WriteLine($"Facebook'ta yayınlanacaktır.");
            Console.WriteLine($"Instagram'da yayınlanacaktır.");
            Console.WriteLine("*********************");

            context.Publish<IProductRegisteredEvent>(new Product()
            {
                ProductName = context.Message.ProductName,
                Quantity = context.Message.Quantity
            });
        }
    }
}