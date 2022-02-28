using MediatR;


namespace ApartmentManagement.Application.Features.Commands.Messages.DeleteMessage
{
    public class DeleteMessageCommandRequest:IRequest<DeleteMessageCommandResponse>
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
    }
}
