using MediatR;


namespace ApartmentManagement.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandRequest:IRequest<DeleteUserCommandResponse>
    {
        public int Id { get; set; }
    }
}
