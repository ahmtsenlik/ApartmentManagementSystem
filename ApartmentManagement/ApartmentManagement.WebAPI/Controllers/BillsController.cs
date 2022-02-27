using ApartmentManagement.Application.Features.Commands.Bills.Add;
using ApartmentManagement.Application.Features.Commands.Bills.AddBulk;
using ApartmentManagement.Application.Features.Queries.Bills.GetBill.BillId;
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
                return Created("", result);
            else
                return BadRequest(result);

        }
        [HttpPost]
        [Route("Bulk")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBulkBill(AddBulkBillCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result);
            else
                return BadRequest(result);

        }
        [HttpGet]
        [Route("List")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBills([FromQuery]bool? isPaid)
        {
            var result = await _mediator.Send(new GetBillsQueryRequest { IsPaid=isPaid});
            return Ok(result);
        }
        
        [HttpGet("User/{Id}")]
        public async Task<IActionResult> GetBillByUserId(int Id)
        {
            //var billByUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //if (User.FindFirst(ClaimTypes.Role).Value == "Admin")
            //{
            //    billByUserId = Id;
            //}
            
            var result = await _mediator.Send(new GetBillByUserIdQueryRequest(){UserId= Id });
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBillById(int Id)
        {
            var result = await _mediator.Send(new GetBillByIdQueryRequest() { Id = Id });
            return Ok(result);
        }
    }
}
