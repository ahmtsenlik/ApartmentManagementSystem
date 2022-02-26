using ApartmentManagement.Application.Features.Commands.Messages.SendMessage;
using ApartmentManagement.Application.Features.Queries.Messages.GetMessages;
using ApartmentManagement.MessageContracts;
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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommandRequest request)
        {
            request.SenderId= int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Created("", result);
            else
                return BadRequest(result);

        }
        [HttpGet("User")] 
        public async Task<IActionResult> GetMessages()
        {
            var userId= int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = await _mediator.Send(new GetMessagesRequest() { UserId=userId});
            return Ok(result);
        }
       
      
    }
}
