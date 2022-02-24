using MediatR;

namespace ApartmentManagement.Application.Features.Commands.Apartments.RemoveUser
{
    public class RemoveUserCommandRequest:IRequest<RemoveUserCommandResponse>
    {
        public int ApartmentId { get; set; }
    }
}
