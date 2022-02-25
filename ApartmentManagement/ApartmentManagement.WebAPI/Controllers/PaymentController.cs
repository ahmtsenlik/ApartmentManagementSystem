
using ApartmentManagement.MessageContracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IBus _bus;
        public PaymentController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost("Payment")]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest paymentModel)
        {
            if (paymentModel is not null)
            {
                Uri uri = new Uri(RabbitMqConsts.RabbitMqUri+RabbitMqConsts.RequestQueue);
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(paymentModel);
                return Ok();
            }
            return BadRequest();

        }
    }
}
