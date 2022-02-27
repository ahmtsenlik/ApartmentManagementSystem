using ApartmentManagement.Application.Features.Commands.Payments;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill.BillId;
using ApartmentManagement.Application.Features.Queries.Payments;
using ApartmentManagement.MessageContracts;
using ApartmentManagement.WebAPI.Helper;
using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public PaymentsController(IBus bus, IMediator mediator, IMapper mapper)
        {
            _bus = bus;
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest paymentModel)
        {
          
            paymentModel.Guid = Guid.NewGuid().ToString();
            Uri uri = new Uri(RabbitMqConsts.RabbitMqUri+RabbitMqConsts.RequestQueue);
            var endPoint = await _bus.GetSendEndpoint(uri);
            

            var bill =await _mediator.Send(new GetBillByIdQueryRequest{Id=paymentModel.BillId});
            if (bill is null)
            {
                return BadRequest("Bill not found.");
            }
            if (bill.IsPaid)
            {
                return BadRequest("This bill has already been paid.");
            }
            paymentModel.Description = bill.Type.ToString();
            paymentModel.Amount = bill.Amount;
           

            await endPoint.Send(paymentModel);
            Thread.Sleep(5000);
            var response= await _mediator.Send(new GetPaymentQueryRequest{Guid=paymentModel.Guid});
            if (response.IsPaid)
            {
                return Ok(response);
               
            }  

            return BadRequest(response);
        }
    }
}
