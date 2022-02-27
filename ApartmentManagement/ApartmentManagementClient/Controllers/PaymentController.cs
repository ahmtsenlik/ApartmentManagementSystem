using ApartmentManagementClient.Models.Bills;
using ApartmentManagementClient.Models.Payment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Controllers
{
    public class PaymentController : Controller
    {
        HttpClient _client;
        
        public PaymentController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }
        
        public IActionResult Index()
        {    
            return View();
        }
        public IActionResult Back()
        {
            return Redirect("~/Bill");
        }
        [Route("Bill/Payment/{id}")]
        public async Task<IActionResult>Pay(PaymentModel payment,int id)
        {
            HttpResponseMessage billResponse = await _client.GetAsync($"/api/Bills/{id}");
            var result = billResponse.Content.ReadAsStringAsync().Result;

            var bill = JsonConvert.DeserializeObject<BillDetailViewModel>(result);
            payment.BillId = bill.Id;
            payment.Description = bill.Type;
            payment.Amount = bill.Amount;
            //userid eksik

            var response = await _client.PostAsJsonAsync<PaymentModel>("api/Payments/Pay", payment);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("~/Bill");
            }
            if (response.StatusCode==System.Net.HttpStatusCode.BadRequest)
            {
                ViewData["ErrorMessage"] = "The information you entered is incorrect, please check your information.";
            }

            return View();
        }
     
    }
}
