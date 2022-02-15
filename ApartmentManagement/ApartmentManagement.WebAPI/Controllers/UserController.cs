using ApartmentManagement.Application.Features.Commands.Users.Signup;
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
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> SignUp(SignupUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Created("", result.Message);

            return BadRequest("User not created.");
        }
    }
}
