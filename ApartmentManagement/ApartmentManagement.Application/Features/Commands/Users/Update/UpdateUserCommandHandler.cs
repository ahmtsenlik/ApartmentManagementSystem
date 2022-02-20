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

namespace ApartmentManagement.Application.Features.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        
        private readonly UpdateUserCommandValidator _validator;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(UserManager<User> userManager, UpdateUserCommandValidator validator, IMapper mapper)
        {
            _userManager = userManager;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new UpdateUserCommandResponse
                {
                    Message = validationResult.ToString(),
                    IsSuccess = false
                };
            }
            var updateUser = await _userManager.FindByIdAsync(request.Id);
            if (updateUser is null)
            {
                return new UpdateUserCommandResponse
                {
                    Message = "The user with this id could not be found.",
                    IsSuccess = false
                };
            }
          
            _mapper.Map(request, updateUser, typeof(UpdateUserCommandRequest), typeof(User));
         
            await _userManager.UpdateAsync(updateUser);
            
            return new UpdateUserCommandResponse
            {
                IsSuccess = true
            };
            
        }
    }
}
