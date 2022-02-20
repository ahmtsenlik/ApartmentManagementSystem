using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryValidator : AbstractValidator<GetApartmentQueryRequest>
    {
        public GetApartmentQueryValidator()
        {
            RuleFor(c => c.ApartmentId).NotEmpty().WithMessage("{ApartmentId} is required.");
        }
    }
}
