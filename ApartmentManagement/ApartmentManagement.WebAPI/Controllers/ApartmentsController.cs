using ApartmentManagement.Application.Features.Commands.Apartments.AddUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Create;
using ApartmentManagement.Application.Features.Commands.Apartments.Remove;
using ApartmentManagement.Application.Features.Commands.Apartments.RemoveUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Update;
using ApartmentManagement.Application.Features.Queries.Apartments.GetApartment;
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
        
        [HttpGet("id")]
        public async Task<IActionResult> GetApartment()
        {
            var id= int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _mediator.Send(new GetApartmentQueryRequest(){ Id = id });
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
                return Created("", result.Message);

            return BadRequest(result.Message);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
        }
        [HttpPut]
        [Route("AddUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser(AddUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
        }
        [HttpPut]
        [Route("RemoveUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUser(RemoveUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveApartment(RemoveApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.Message);
        }
    }
}