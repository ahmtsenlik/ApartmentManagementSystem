﻿using ApartmentManagement.Application.Features.Commands.Authentication.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagement.WebAPI.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginUserCommandRequest request)
        {
            var result=await _mediator.Send(request);

            if (result.IsSuccess)
            {
                return Ok("Login successful.");
            }
            return result != null ? Created("", result) : (IActionResult)BadRequest(result);
        }
    }
}
