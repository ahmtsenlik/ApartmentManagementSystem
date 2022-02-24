using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Services;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.Create
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommandRequest, CreateApartmentCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly CreateApartmentCommandValidator _validator;
        private readonly ICacheService _cacheService;

        public CreateApartmentCommandHandler(IApartmentRepository apartmentRepository,IMapper mapper, CreateApartmentCommandValidator validator, ICacheService cacheService)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = validator; 
            _cacheService = cacheService;
        }

        public async Task<CreateApartmentCommandResponse> Handle(CreateApartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult=_validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new CreateApartmentCommandResponse
                {
                    Message = validationResult.ToString(),
                    IsSuccess = false
                };
            }
           
            var checkApartment= await _apartmentRepository.GetAsync(apt => apt.Block == request.Block && apt.No == request.No && apt.Floor == request.Floor);
            if (checkApartment.Count!=0)
            {
                return new CreateApartmentCommandResponse
                {
                    Message = "This apartment has already been registered",
                    IsSuccess = false
                };
            }
            
            var apartment = _mapper.Map<Apartment>(request);
            apartment.IsEmpty = true;
            await _apartmentRepository.AddAsync(apartment);

            _cacheService.Remove("ApartmentList");
            return new CreateApartmentCommandResponse
            {
                IsSuccess = true,
                Message = "Apartment created."
            };
        }
    }
}
