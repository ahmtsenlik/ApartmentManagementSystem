using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Services;
using ApartmentManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ICacheService _cacheService;
        public DeleteUserCommandHandler(UserManager<User> userManager, IApartmentRepository apartmentRepository, ICacheService cacheService)
        {
            _userManager = userManager;
            _apartmentRepository = apartmentRepository;
            _cacheService = cacheService;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            var checkApartment =await _apartmentRepository.GetSingleAsync(x => x.UserId == user.Id);
            if (checkApartment is not null)
            {
                return new DeleteUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "Remove the user from the apartment before deleting them."
                };

            }
            await _userManager.DeleteAsync(user);
            _cacheService.Remove("UserList");
            return new DeleteUserCommandResponse
            {
                IsSuccess = true,
                Message = "The user has been deleted."
            };

        }
    }
}
