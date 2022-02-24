using MediatR;


namespace ApartmentManagement.Application.Features.Commands.Users.Signup
{
    public class SignupUserCommandRequest:IRequest<SignupUserCommandResponse>
    {
        
        public string TCIdentityNumber { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string LicensePlate { get; set; }
        public bool IsOwner { get; set; }


    }
}
