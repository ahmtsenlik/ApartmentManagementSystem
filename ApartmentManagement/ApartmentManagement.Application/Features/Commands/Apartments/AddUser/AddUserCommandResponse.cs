using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.AddUser
{
    public class AddUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
