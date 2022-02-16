using ApartmentManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        
        private readonly UpdateUserCommandValidator _validator;

        public UpdateUserCommandHandler(UserManager<User> userManager, UpdateUserCommandValidator validator)
        {
            _userManager = userManager;
            _validator = validator;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updateUser = await _userManager.FindByIdAsync(request.Id);
            if (updateUser is null)
            {
                return new UpdateUserCommandResponse
                {
                    Message = "The user with this id could not be found.",
                    IsSuccess = false
                };
            }
            var validateResult = _validator.Validate(request);
            if (!validateResult.IsValid)
            {
                return new UpdateUserCommandResponse
                {
                    Message = validateResult.ToString(),
                    IsSuccess = false        
                };
            }

            updateUser.TCIdentityNumber = request.TCIdentityNumber;
            updateUser.FirstName = request.FirstName;
            updateUser.LastName = request.LastName;
            updateUser.Email = request.Email;
            updateUser.PhoneNumber = request.PhoneNumber;
            updateUser.LicensePlate = request.LicensePlate;
           
            await _userManager.UpdateAsync(updateUser);
            
            return new UpdateUserCommandResponse
            {
                IsSuccess = true
            };
            
        }
    }
}
