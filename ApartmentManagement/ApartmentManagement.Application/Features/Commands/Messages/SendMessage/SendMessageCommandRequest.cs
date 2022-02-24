using MediatR;

namespace ApartmentManagement.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandRequest:IRequest<SendMessageCommandResponse>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
