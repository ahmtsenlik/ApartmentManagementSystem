using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.ChangePass
{
    public class ChangePassCommandRequest:IRequest<ChangePassCommandResponse>
    {
        public int UserId { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        
    }
}
