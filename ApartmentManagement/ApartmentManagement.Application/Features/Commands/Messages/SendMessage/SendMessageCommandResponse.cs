using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
