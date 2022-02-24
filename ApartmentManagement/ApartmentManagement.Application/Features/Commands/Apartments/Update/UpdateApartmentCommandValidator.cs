using FluentValidation;


namespace ApartmentManagement.Application.Features.Commands.Apartments.Update
{
    public class UpdateApartmentCommandValidator : AbstractValidator<UpdateApartmentCommandRequest>
    {
        public UpdateApartmentCommandValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(c => c.Block).NotEmpty().WithMessage("{Block} is required")
                .MaximumLength(3).WithMessage("The block number must be a maximum of 3 digits.");

            RuleFor(c => c.No).NotEmpty().WithMessage("{No} is required")
                .GreaterThan(0).WithMessage("No must be greater than 0");

            RuleFor(c => c.NumberOfRooms).NotEmpty().WithMessage("{NumberOfRooms} is required")
                .MaximumLength(4).WithMessage("The room number must be a maximum of 4 digits.");

            RuleFor(c => c.Floor).NotEmpty().WithMessage("{Floor} is required")
                .GreaterThan(-10).WithMessage("Floor number must be greater than -10")
                .LessThan(100).WithMessage("Floor number must be less than 100");
        }
    }
}
