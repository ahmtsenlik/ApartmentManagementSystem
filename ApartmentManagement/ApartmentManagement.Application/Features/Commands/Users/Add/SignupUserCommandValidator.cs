using FluentValidation;


namespace ApartmentManagement.Application.Features.Commands.Users.Signup
{
    public class SignupUserCommandValidator : AbstractValidator<SignupUserCommandRequest>
    {
        public SignupUserCommandValidator()
        {
            RuleFor(c => c.IsOwner).NotNull().WithMessage("{IsOwner} is required..");

            RuleFor(c => c.TCIdentityNumber).Length(11).WithMessage("TR Identity Number must be 11 characters.");

            RuleFor(c => c.Username).NotEmpty().WithMessage("{User Name} is required.")
                .MaximumLength(256).WithMessage("{User Name} can be a maximum of 256 characters.");   

            RuleFor(c => c.FirstName).NotEmpty().WithMessage("{First Name} is required.");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("{Last Name} is required.");

            RuleFor(c => c.Email).NotEmpty().WithMessage("{Email} is required.")
                .MaximumLength(256).WithMessage("{Email} can be a maximum of 256 characters.")
                .EmailAddress().WithMessage("{Email} format is wrong.");

            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("{Phone Number} is required.");

            RuleFor(c => c.LicensePlate).MaximumLength(256).WithMessage("{LicensePlate} can be a maximum of 256 characters.");
            
        }
    }
}
