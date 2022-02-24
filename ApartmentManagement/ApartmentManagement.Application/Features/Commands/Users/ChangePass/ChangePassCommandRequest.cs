using MediatR;

namespace ApartmentManagement.Application.Features.Commands.Users.ChangePass
{
    public class ChangePassCommandRequest:IRequest<ChangePassCommandResponse>
    {
        public int UserId { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        
    }
}
