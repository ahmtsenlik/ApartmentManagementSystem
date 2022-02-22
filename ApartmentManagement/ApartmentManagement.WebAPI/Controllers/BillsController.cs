using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill;
using ApartmentManagement.Application.Features.Queries.Bills.GetPaidBills;
using ApartmentManagement.Application.Features.Queries.Bills.GetUnPaidBills;
using MediatR;
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
    public class BillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(AddBillCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result.Message);
            else
                return BadRequest(result.Message);

        }
        [HttpGet]
        [Route("UnPaidList")]
        public async Task<IActionResult> GetUnPaidBills()
        {
            var result = await _mediator.Send(new GetUnPaidBillsQueryRequest());
            return Ok(result);
        }
        [HttpGet]
        [Route("PaidList")]
        public async Task<IActionResult> GetPaidBills()
        {
            var result = await _mediator.Send(new GetPaidBillsQueryRequest());
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBill(int userId)
        {
            var result = await _mediator.Send(new GetBillQueryRequest(){UserId=userId});
            return Ok(result);
        }
    }
}
