using MediatR;

namespace ApartmentManagement.Application.Features.Commands.Apartments.AddUser
{
    public class AddUserCommandRequest:IRequest<AddUserCommandResponse>
    {
        public string UserId { get; set; }
        public int  ApartmentId { get; set; }
    }
}
