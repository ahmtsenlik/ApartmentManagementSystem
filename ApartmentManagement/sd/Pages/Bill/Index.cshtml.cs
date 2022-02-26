using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagementClient.Models.Bills;
using ApartmentManagementClient.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ApartmentManagementClient.Pages.Bills
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBillService _billService;
        public List<GetBillViewModel> GetBillsViewModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

     

        public void OnGet()
        {
            GetBillsViewModel = _billService.GetAllBills().Result;

        }
    }
}
