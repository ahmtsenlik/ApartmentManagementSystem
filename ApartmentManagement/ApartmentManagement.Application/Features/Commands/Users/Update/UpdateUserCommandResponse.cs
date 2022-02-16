using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.Update
{
    public class UpdateUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
