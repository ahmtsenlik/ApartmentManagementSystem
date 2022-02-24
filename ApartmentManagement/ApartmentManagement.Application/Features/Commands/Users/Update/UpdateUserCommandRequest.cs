using MediatR;


namespace ApartmentManagement.Application.Features.Commands.Users.Update
{
    public class UpdateUserCommandRequest:IRequest<UpdateUserCommandResponse>
    {
        public string Id { get; set; }
        public string TCIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LicensePlate { get; set; }
        public bool IsOwner { get; set; }
        public string Role { get; set; }

    }
}
