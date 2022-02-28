using ApartmentManagement.Application.Features.Commands.Users.ChangePass;
using ApartmentManagement.Application.Features.Commands.Users.DeleteUser;
using ApartmentManagement.Application.Features.Commands.Users.Signup;
using ApartmentManagement.Application.Features.Commands.Users.Update;
using ApartmentManagement.Application.Features.Queries.Users.GetUser;
using ApartmentManagement.Application.Features.Queries.Users.GetUsers;
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
  //  [Authorize]
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
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersQueryRequest());
            return Ok(result);
        }

        [HttpGet("{Id}")]
        
        public async Task<IActionResult> GetUser(int Id)
        {
            var ByUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (User.FindFirst(ClaimTypes.Role).Value == "Admin")
            {
                ByUserId = Id;
            }

            var result = await _mediator.Send(new GetUserQueryRequest { Id= ByUserId });
            return Ok(result);
        }

        [HttpPost("Register")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignUpUser(SignupUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Created("", result);

            return BadRequest(result);
        }
        
        [HttpPut]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
           var result= await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();
            
            return BadRequest(result);
        }
        [HttpPut("ChangePass")]
        public async Task<IActionResult> UpdatePass(ChangePassCommandRequest request)
        {
            request.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result);
        }
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            //var ByUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //if (User.FindFirst(ClaimTypes.Role).Value == "Admin")
            //{
            //    ByUserId = Id;
            //}

            var result = await _mediator.Send(new DeleteUserCommandRequest { Id = Id });
            return Ok(result);
        }
    }
}
