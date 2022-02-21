using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill;
using ApartmentManagement.Application.Features.Queries.Bills.GetBills;
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
    public class BillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillController(IMediator mediator)
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
        [Route("List")]
        public async Task<IActionResult> GetBills()
        {
            var result = await _mediator.Send(new GetBillsQueryRequest());
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
