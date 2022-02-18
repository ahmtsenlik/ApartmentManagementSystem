using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandRequest:IRequest<SendMessageCommandResponse>
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
