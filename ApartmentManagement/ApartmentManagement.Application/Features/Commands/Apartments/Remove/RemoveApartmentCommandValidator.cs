using FluentValidation;


namespace ApartmentManagement.Application.Features.Commands.Apartments.Remove
{
    public class RemoveApartmentCommandValidator : AbstractValidator<RemoveApartmentCommandRequest>
    {
        public RemoveApartmentCommandValidator()
        {
            RuleFor(c => c.ApartmentId).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
