using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Services;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Apartments.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly AddUserCommandValidator _validator;
        private readonly UserManager<User> _userManager;
        private readonly ICacheService _cacheService;
        public AddUserCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper, AddUserCommandValidator validator, UserManager<User> userManager, ICacheService cacheService)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = validator;
            _userManager = userManager;
            _cacheService = cacheService;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new AddUserCommandResponse
                {
                    Message = validationResult.ToString(),
                    IsSuccess = false
                };
            }
            
            var checkUser = await _userManager.FindByIdAsync(request.UserId.ToString());
        
            if (checkUser is null)
            {
                return new AddUserCommandResponse
                {
                    Message = "The user with this id could not be found.",
                    IsSuccess = false
                };
            }
            
            var updateApartment = await _apartmentRepository.GetSingleAsync(x=>x.Id==request.ApartmentId,x=>x.User);
            if (updateApartment is null)
            {
                return new AddUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment was not found."
                };
            }

            if (!updateApartment.IsEmpty)
            {
                return new AddUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "This apartment is already full."
                };
            }
            //User başka bir dairede mi?
            var checkApartment = await _apartmentRepository.GetSingleAsync(x => x.UserId == checkUser.Id);
            if(checkApartment is not null)
            {
                return new AddUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "There is a user who lives here."
                };
            }

            _mapper.Map(request, updateApartment, typeof(AddUserCommandRequest), typeof(Apartment));
            updateApartment.User = checkUser;
            updateApartment.IsEmpty = false;
            await _apartmentRepository.UpdateAsync(updateApartment);

            _cacheService.Remove("ApartmentList");
            return new AddUserCommandResponse
            {
                IsSuccess =true         
            };

        }
    }
}
