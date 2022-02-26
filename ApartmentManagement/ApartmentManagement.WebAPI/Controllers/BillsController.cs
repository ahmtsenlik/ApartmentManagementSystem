using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Application.Features.Commands.Bills.AddBulk;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill.UserId;
using ApartmentManagement.Application.Features.Queries.Bills.GetBills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.Controllers
{
    //[Authorize]
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
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBill(AddBillCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result.Message);
            else
                return BadRequest(result.Message);

        }
        [HttpPost]
        [Route("Bulk")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBulkBill(AddBulkBillCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result.Message);
            else
                return BadRequest(result.Message);

        }
        [HttpGet]
        [Route("List")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPaidBills([FromQuery]GetBillsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("User")]
        public async Task<IActionResult> GetBill()
        {
            var userId=int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _mediator.Send(new GetBillByUserIdRequest(){UserId=userId});
            return Ok(result);
        }
    }
}
