using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly RemoveUserCommandValidator _validator;
        private readonly ICacheService _cacheService;
        public RemoveUserCommandHandler(IApartmentRepository apartmentRepository, RemoveUserCommandValidator validator,ICacheService cacheService)
        {
            _apartmentRepository = apartmentRepository;
            _validator = validator;
            _cacheService = cacheService;
        }

        public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new RemoveUserCommandResponse
                {
                    Message = validationResult.ToString(),
                    IsSuccess = false
                };
            }

            var updateApartment = await _apartmentRepository.GetSingleAsync(x=>x.Id==request.ApartmentId,x=>x.User);

            if (updateApartment is null)
            {
                return new RemoveUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment was not found."
                };
            }
           
            if (updateApartment.IsEmpty)
            {
                return new RemoveUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "This apartment is already empty"
                };
            }
  
            updateApartment.User = null;
            updateApartment.UserId = null;
            updateApartment.IsEmpty = true;
            await _apartmentRepository.UpdateAsync(updateApartment);
            _cacheService.Remove("ApartmentList");
            return new RemoveUserCommandResponse
            {
                IsSuccess = true
            };

        }
    }
}
