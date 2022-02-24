using FluentValidation;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryValidator : AbstractValidator<GetApartmentQueryRequest>
    {
        public GetApartmentQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("{ApartmentId} is required.");
        }
    }
}
