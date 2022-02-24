using MediatR;


namespace ApartmentManagement.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandRequest:IRequest<LoginUserCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
