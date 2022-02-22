using ApartmentManagement.Application.Services;
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

namespace ApartmentManagement.Application.Features.Queries.Users.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, IList<GetUsersQueryResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetUsersQueryHandler(UserManager<User> userManager, IMapper mapper, ICacheService cacheService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<IList<GetUsersQueryResponse>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = "UserList";

           /* if (_cacheService.TryGet(cacheKey, out List<GetUsersQueryResponse> cacheList))
            {
                return cacheList;
            }*/
            var users = _userManager.Users.ToList();
            var userList = _mapper.Map<IList<GetUsersQueryResponse>>(users);
            _cacheService.Set(cacheKey, userList);
            return userList;
        }
    }
}
