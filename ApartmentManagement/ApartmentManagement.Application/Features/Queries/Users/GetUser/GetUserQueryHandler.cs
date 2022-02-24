using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public GetUserQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            return _mapper.Map<GetUserQueryResponse>(user);
        }
    }
}
