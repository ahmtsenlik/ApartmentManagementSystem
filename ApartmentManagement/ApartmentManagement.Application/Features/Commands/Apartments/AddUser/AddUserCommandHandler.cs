using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public AddUserCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper, AddUserCommandValidator validator, UserManager<User> userManager)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _validator = validator;
            _userManager = userManager;
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
            var checkUser = await _userManager.FindByIdAsync(request.UserId);
            if (checkUser is null)
            {
                return new AddUserCommandResponse
                {
                    Message = "The user with this id could not be found.",
                    IsSuccess = false
                };
            }
            
            var updateApartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);
            if (updateApartment is null)
            {
                return new AddUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "The apartment was not found."
                };
            }
            if (updateApartment.User is not null)
            {
                return new AddUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "There is a user who lives here."
                };
            }
            
            
            _mapper.Map(request, updateApartment, typeof(AddUserCommandRequest), typeof(Apartment));
            updateApartment.User = checkUser;
            await _apartmentRepository.UpdateAsync(updateApartment);
            return new AddUserCommandResponse
            {
                IsSuccess =true         
            };

        }
    }
}
