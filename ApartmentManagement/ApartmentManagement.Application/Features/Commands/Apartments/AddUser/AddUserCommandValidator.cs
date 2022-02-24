using FluentValidation;


namespace ApartmentManagement.Application.Features.Commands.Apartments.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommandRequest>
    {
        public AddUserCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("{UserId} is required.");

            RuleFor(c => c.ApartmentId).NotEmpty().WithMessage("{ApartmentId} is required.");
        }
        
    }
}
