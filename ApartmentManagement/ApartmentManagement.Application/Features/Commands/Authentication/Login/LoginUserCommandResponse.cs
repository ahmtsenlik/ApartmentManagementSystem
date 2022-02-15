using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandResponse
    {
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}
