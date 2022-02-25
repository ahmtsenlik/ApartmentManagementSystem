using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagementClient.Models.Aparments;
using ApartmentManagementClient.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ApartmentManagementClient.Pages.Apartment
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApartmentService _apartmentService;
        public List<GetApartmentViewModel> ApartmentsViewModel { get; set; }
       
        public IndexModel(ILogger<IndexModel> logger, IApartmentService apartmentService)
        {
            _logger = logger;
            _apartmentService = apartmentService;
        }
        public void OnGet()
        {
            ApartmentsViewModel = _apartmentService.GetAllApartments().Result;

        }
    }
}
