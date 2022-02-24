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
        public LoginUserCommandValidator()
        {
            RuleFor(c => c.Username).NotEmpty().WithMessage("{Username} is required.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("{Password} is required.");
        }
    }
}
