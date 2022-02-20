using ApartmentManagement.Application.Features.Commands.Apartments.AddUser;
using ApartmentManagement.Application.Features.Commands.Apartments.Create;
using ApartmentManagement.Application.Features.Commands.Apartments.Remove;
using ApartmentManagement.Application.Features.Commands.Apartments.Update;
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
    public class ApartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApartment(CreateApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result.Message);

            return BadRequest(result.Message);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
        }
        [HttpPut]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(AddUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveApartment(RemoveApartmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
         
            return BadRequest(result);
            }
    }
}