using ApartmentManagementClient.Models.Aparments;
using ApartmentManagementClient.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApartmentService _apartmentService;
        public GetApartmentViewModel ApartmentViewModel { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IApartmentService apartmentService)
        {
            _logger = logger;
            _apartmentService = apartmentService;
        }

        public void OnGet()
        {
            ApartmentViewModel = _apartmentService.GetApartmentByUserId().Result;
          
        }
    }
}
