using ApartmentManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.ChangePass
{
    public class ChangePassCommandHandler : IRequestHandler<ChangePassCommandRequest, ChangePassCommandResponse>
    {
        private readonly UserManager<User> _userManager;

        public ChangePassCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ChangePassCommandResponse> Handle(ChangePassCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var result = await _userManager.ChangePasswordAsync(user, request.OldPass, request.NewPass);
            if (!result.Succeeded)
            {
                return new ChangePassCommandResponse
                {
                    IsSuccess = false,
                    Message = result.ToString()
                };
            }
            return new ChangePassCommandResponse
            {
                IsSuccess = true,
                Message = "Your password has been changed."
            };
        }
    }
}
