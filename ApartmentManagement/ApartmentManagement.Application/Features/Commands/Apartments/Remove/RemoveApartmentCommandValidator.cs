using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
