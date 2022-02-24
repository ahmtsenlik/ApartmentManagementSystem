using FluentValidation;

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
