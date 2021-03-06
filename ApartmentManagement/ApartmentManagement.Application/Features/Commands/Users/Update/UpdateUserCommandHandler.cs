using ApartmentManagement.Application.Services;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        
        private readonly UpdateUserCommandValidator _validator;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public UpdateUserCommandHandler(UserManager<User> userManager, UpdateUserCommandValidator validator, IMapper mapper, ICacheService cacheService)
        {
            _userManager = userManager;
            _validator = validator;
            _mapper = mapper;
            _cacheService = cacheService;
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
            if (!(request.Role=="Admin"|| request.Role == "User"))
            {

                return new UpdateUserCommandResponse
                {
                    Message = "The role must be Admin or User.",
                    IsSuccess = false
                };
            }
            var updateUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (updateUser is null)
            {
                return new UpdateUserCommandResponse
                {
                    Message = "The user with this id could not be found.",
                    IsSuccess = false
                };
            }
          
            _mapper.Map(request, updateUser, typeof(UpdateUserCommandRequest), typeof(User));
            await _userManager.AddToRoleAsync(updateUser, request.Role);
            await _userManager.UpdateAsync(updateUser);

            _cacheService.Remove("UserList");
            return new UpdateUserCommandResponse
            {
                IsSuccess = true
            };
            
        }
    }
}
