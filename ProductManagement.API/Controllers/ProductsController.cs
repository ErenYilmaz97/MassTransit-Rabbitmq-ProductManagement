using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Commands;
using ProductManagement.MessageContracts.Models;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> RegisterProduct([FromBody] Product product)
        {
            var bus = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitmqConstants.RabbitMqUri}/{RabbitmqConstants.RegistrationServiceQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            await endPoint.Send<IProductRegistrationCommand>(product);
            return Ok("Ürün Eklenmek üzere teslim alındı.");
        }
    }
}
