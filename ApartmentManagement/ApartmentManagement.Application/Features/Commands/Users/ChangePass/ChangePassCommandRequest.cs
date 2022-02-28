using MediatR;

namespace ApartmentManagement.Application.Features.Commands.Users.ChangePass
{
    public class ChangePassCommandRequest:IRequest<ChangePassCommandResponse>
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        
    }
}
