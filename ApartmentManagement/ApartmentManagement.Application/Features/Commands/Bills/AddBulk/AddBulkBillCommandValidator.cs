using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Bills.AddBulk
{
    public class AddBulkBillCommandValidator : AbstractValidator<AddBulkBillCommandRequest>
    {
        public AddBulkBillCommandValidator()
        {
                RuleFor(c => c.Amount).NotEmpty().WithMessage("{Amount} is required.");

                RuleFor(c => c.Month).GreaterThan(0).LessThanOrEqualTo(12).WithMessage("{Month} must be between 0 and 12.");

                RuleFor(c => c.Year).GreaterThan(2021).WithMessage("The year must be greater than 2021.");

                RuleFor(c => ((int)c.Type)).GreaterThanOrEqualTo(0).LessThanOrEqualTo(3).WithMessage("{Month} must be between 0 and 4.");
        }
    }
}
