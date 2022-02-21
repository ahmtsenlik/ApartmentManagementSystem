using ApartmentManagement.Application.Features.Commands.Messages.SendMessage;
using ApartmentManagement.Application.Features.Queries.Messages.GetMessages;
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
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result.Message);
            else
                return BadRequest(result.Message);

        }
        [HttpGet("{userId}")] 
        public async Task<IActionResult> GetMessages(int userId)
        {
            var result = await _mediator.Send(new GetMessagesRequest() { UserId=userId});
            return Ok(result);
        }
    }
}
