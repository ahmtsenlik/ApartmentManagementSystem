using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Create
{
    public class CreateApartmentCommandValidator : AbstractValidator<CreateApartmentCommandRequest>
    {
        public CreateApartmentCommandValidator()
        {
            RuleFor(c => c.Block).NotEmpty().WithMessage("{Block} is required");

            RuleFor(c => c.No).NotEmpty().WithMessage("{No} is required");

            RuleFor(c => c.NumberOfRooms).NotEmpty().WithMessage("{NumberOfRooms} is required");

            RuleFor(c => c.Floor).NotEmpty().WithMessage("{Floor} is required");
        }
    }
}
