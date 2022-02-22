using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.RemoveUser
{
    public class RemoveUserCommandRequest:IRequest<RemoveUserCommandResponse>
    {
        public int ApartmentId { get; set; }
    }
}
