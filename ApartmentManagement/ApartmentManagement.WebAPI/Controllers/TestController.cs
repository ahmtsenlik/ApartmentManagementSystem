
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
    public class TestController : ControllerBase
    {
        private readonly IBus _bus;
        public TestController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost("rabbit")]
        public async Task<IActionResult> Rabbit([FromBody] Todo denememodel)
        {
            if (denememodel is not null)
            {
                Uri uri = new Uri(RabbitMqConsts.RabbitMqUri);
                var endPoint = await _bus.GetSendEndpoint(uri);
                denememodel.mesaj = "Ahmet Şenlik";
                await endPoint.Send(denememodel);
                return Ok();
            }
            return BadRequest();

        }
    }
}
