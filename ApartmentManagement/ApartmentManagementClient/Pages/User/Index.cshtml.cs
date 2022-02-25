using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagementClient.Models;
using ApartmentManagementClient.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ApartmentManagementClient.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        public List<UserViewModel> UsersViewModel { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService =userService;
        }



        public void OnGet()
        {
            UsersViewModel = _userService.GetAllUsers().Result;

        }
    }
}
