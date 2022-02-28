using ApartmentManagement.Application.Features.Commands.Apartments.AddUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Create;
using ApartmentManagement.Application.Features.Commands.Apartments.Remove;
using ApartmentManagement.Application.Features.Commands.Apartments.RemoveUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Update;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartment;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartmentByUserId;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetApartment(int Id)
        {
            
            var result = await _mediator.Send(new GetApartmentQueryRequest() { Id = Id });
            return Ok(result);
        }
        [HttpGet("User/{Id}")]
        public async Task<IActionResult> GetApartmentByUserId(int Id)
        {
            var apartmentByUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (User.FindFirst(ClaimTypes.Role).Value == "Admin")
            {
                apartmentByUserId = Id;
            }
            var result = await _mediator.Send(new GetApartmentByUserIdQueryRequest() { UserId  = apartmentByUserId });
            return Ok(result);
        }

        [HttpGet]
        [Route("List")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetApartments()
        {
            var result = await _mediator.Send(new GetApartmentsQueryRequest());
            return Ok(result);

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateApartment(CreateApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result);

            return BadRequest(result);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result);
        }
        [HttpPut]
        [Route("AddUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser(AddUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result);
        }
        [HttpDelete("RemoveUser/{ApartmentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUser(int ApartmentId)
        {
            var result = await _mediator.Send(new RemoveUserCommandRequest{ ApartmentId=ApartmentId});
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result);
        }
        [HttpDelete("{Id}")]
       [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveApartment(int Id)
        {
            var result = await _mediator.Send(new RemoveApartmentCommandRequest {ApartmentId=Id});
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result);
        }
    }
}