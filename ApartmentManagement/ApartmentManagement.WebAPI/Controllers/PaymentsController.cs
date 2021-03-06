using ApartmentManagement.Application.Features.Commands.Payments;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill.BillId;
using ApartmentManagement.Application.Features.Queries.Payments.GetPayment;
using ApartmentManagement.Application.Features.Queries.Payments.GetPayments;
using ApartmentManagement.MessageContracts;
using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.Controllers
{
    [Authorize]
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
        [HttpGet("{isPaid}")]
        public async Task<IActionResult> GetPayments(bool? isPaid)
        {
            var result= await _mediator.Send(new GetPaymentsQueryRequest { IsPaid = isPaid });
            return Ok(result);

        }
        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest paymentModel)
        {

            if (paymentModel.CardNumber is null|| paymentModel.SecurityCode<100 || paymentModel.ExpYear<2021 || paymentModel.ExpMonth>12)
            {
                return BadRequest("Card information is incorrect.");
            }
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
