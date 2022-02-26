using ApartmentManagementClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserByUserId();
        Task<List<UserViewModel>> GetAllUsers();
    }
}
