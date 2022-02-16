﻿using ApartmentManagement.Application.Features.Commands.Apartments.Create;
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
            var result= await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result.Message);

            return BadRequest(result.Message);         
        }
    }
}
