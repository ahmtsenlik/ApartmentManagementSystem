using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommandRequest>
    {
    }
}
