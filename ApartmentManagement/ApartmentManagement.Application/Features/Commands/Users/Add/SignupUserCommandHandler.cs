using ApartmentManagement.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.Signup
{
    public class SignupUserCommandHandler : IRequestHandler<SignupUserCommandRequest, SignupUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignupUserCommandValidator _validator;

        public SignupUserCommandHandler(UserManager<User> userManager, IMapper mapper, SignupUserCommandValidator validator)
        {
            _userManager = userManager;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<SignupUserCommandResponse> Handle(SignupUserCommandRequest request, CancellationToken cancellationToken)
        { 
            var validationResult=_validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new SignupUserCommandResponse
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
          
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists is not null)
            {
                return new SignupUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "This username is already registered."
                };
            }

            var user= _mapper.Map<User>(request);     
            var defaultpass = "User*123";
            var userCreateResult = await _userManager.CreateAsync(user,defaultpass);
            if (!userCreateResult.Succeeded)
            {
                return new SignupUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "An unexpected error occurred"
                };

            }
            return new SignupUserCommandResponse
            {
                IsSuccess = true,
                Message = "Registration successful."
            };
        }
    }
}
