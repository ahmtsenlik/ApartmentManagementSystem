using ApartmentManagement.Application.Models;

using System.Collections.Generic;


namespace ApartmentManagement.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public LoginUserModel User { get; set; }
    }
}
