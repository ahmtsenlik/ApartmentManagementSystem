using ApartmentManagementClient.Extensions;
using ApartmentManagementClient.Models;
using ApartmentManagementClient.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var response = await _client.GetAsync($"/api/Users/List");
            return await response.ReadContentAs<List<UserViewModel>>();
        }

        public async Task<UserViewModel> GetUserByUserId()
        {
            var response = await _client.GetAsync($"/api/Users/Id");
            return await response.ReadContentAs<UserViewModel>();
        }
    }
}
