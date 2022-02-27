using ApartmentManagement.Application.Exceptions;
using ApartmentManagement.Application.Models;
using ApartmentManagement.Application.Settings;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly LoginUserCommandValidator _validator;
        public LoginUserCommandHandler(UserManager<User> userManager, IOptionsSnapshot<JwtSettings> jwtSettings, IMapper mapper, LoginUserCommandValidator validator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _validator = validator;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {          
            _validator.ValidateAndThrow(request);
            LoginUserCommandResponse response = new LoginUserCommandResponse();
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == request.Username);
            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Username);
            }
            
            var userLoginResult = await _userManager.CheckPasswordAsync(user, request.Password);
            if (userLoginResult)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role,user.Id.ToString())
                    };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Issuer,
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                response.Token = new JwtSecurityTokenHandler().WriteToken(token);  
                response.IsSuccess = true;

            }   
            return response;
        }
        
    }
}
