using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Remove
{
    public class RemoveApartmentCommandHandler : IRequestHandler<RemoveApartmentCommandRequest,RemoveApartmentCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly RemoveApartmentCommandValidator _validator;
        private readonly ICacheService _cacheService;
        public RemoveApartmentCommandHandler(IApartmentRepository apartmentRepository, RemoveApartmentCommandValidator validator, ICacheService cacheService)
        {
            _apartmentRepository = apartmentRepository;
            _validator=validator;
            _cacheService = cacheService;
        }

        public async Task<RemoveApartmentCommandResponse> Handle(RemoveApartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new RemoveApartmentCommandResponse
                {
                    IsSuccess = false,
                    Message = "This apartment has already been registered"
                };
            }

            var removeApartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);

            if (removeApartment is null)
            {
                return new RemoveApartmentCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment with this id could not be found."       
                };
            }

            if (removeApartment is not null && !removeApartment.IsEmpty)
            {
                return new RemoveApartmentCommandResponse
                {
                    IsSuccess = false,
                    Message = "Apartment is full, remove user first."
                };
            }

            await _apartmentRepository.RemoveAsync(removeApartment);
            _cacheService.Remove("ApartmentList");
            return new RemoveApartmentCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
