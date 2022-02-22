using ApartmentManagement.Application.Features.Commands.Users.Signup;
using ApartmentManagement.Application.Features.Commands.Users.Update;
using ApartmentManagement.Application.Features.Queries.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        [Route("List")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersQueryRequest());
            return Ok(result);
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignUpUser(SignupUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Created("", result.Message);

            return BadRequest(result.Message);
        }
        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
           var result= await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();
            
            return BadRequest(result.Message);
        }
    }
}
