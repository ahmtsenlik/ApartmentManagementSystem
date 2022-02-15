﻿using ApartmentManagement.Domain.Entities;
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
            SignupUserCommandResponse response = new SignupUserCommandResponse();

            var validateResult=_validator.Validate(request);
            if (!validateResult.IsValid)
            {
                response.Message = validateResult.ToString();
                return response;
            }
            
           
            var userExists = await _userManager.FindByNameAsync(request.Username);
            
            if (userExists is not null)
            {
                response.Message = "This username is already registered.";
                response.IsSuccess = false;
                return response;
            }
            var user= _mapper.Map<User>(request);
            var defaultpass = "User!123";
            user.UserName = request.Username;

            var userCreateResult = await _userManager.CreateAsync(user,defaultpass);

            if (userCreateResult.Succeeded)
            {
                response.Message = "Registration successful.";
                response.IsSuccess = true;
            }

            return response;
        }
    }
}