using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.AddUser
{
    public class AddUserCommandRequest:IRequest<AddUserCommandResponse>
    {
        public string UserId { get; set; }
        public int  ApartmentId { get; set; }
    }
}
