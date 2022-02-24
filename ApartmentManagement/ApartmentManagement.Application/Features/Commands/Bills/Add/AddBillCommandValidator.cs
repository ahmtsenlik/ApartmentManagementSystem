using FluentValidation;


namespace ApartmentManagement.Application.Features.Commands.Bills.Add
{
    public class AddBillCommandValidator : AbstractValidator<AddBillCommandRequest>
    {
        public AddBillCommandValidator()
        {
            RuleFor(c => c.Amount).NotEmpty().WithMessage("{Amount} is required.");

            RuleFor(c => c.Month).GreaterThan(0).LessThanOrEqualTo(12).WithMessage("{Month} must be between 0 and 12.");

            RuleFor(c => c.Year).GreaterThan(2021).WithMessage("The year must be greater than 2021.");

            RuleFor(c => c.ApartmentId).NotEmpty().WithMessage("{Apartment Id} is required.");

            RuleFor(c => ((int)c.Type)).GreaterThanOrEqualTo(0).LessThanOrEqualTo(3).WithMessage("{Month} must be between 0 and 4.");
        }
    }
}
