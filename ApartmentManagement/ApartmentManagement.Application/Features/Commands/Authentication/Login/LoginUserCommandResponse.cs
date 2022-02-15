using ApartmentManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public UserModel User { get; set; }
    }
}
