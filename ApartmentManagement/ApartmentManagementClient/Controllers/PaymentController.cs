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
        public async Task<IActionResult> Index(PaymentModel payment)
        {
            HttpResponseMessage billResponse = await _client.GetAsync($"/api/Bills/{payment.BillId}");
            var result = billResponse.Content.ReadAsStringAsync().Result;

            var bill = JsonConvert.DeserializeObject<BillDetailViewModel>(result);

            payment.Description = bill.Type;
            payment.Amount = bill.Amount;
            //userid eksik

            var response= await _client.PostAsJsonAsync<PaymentModel>("api/Payments/pay", payment);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewData["ErrorMessage"] = Validation(response);

            return View();
        }
        public string Validation(HttpResponseMessage check)
        {
            var httpErrorObject = check.Content.ReadAsStringAsync().Result;

            // Create an anonymous object to use as the template for deserialization:
            var anonymousErrorObject =
                new { message = "", ModelState = new Dictionary<string, string[]>() };

            // Deserialize:
            var deserializedErrorObject =
                JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);

            return deserializedErrorObject.message;

        }
    }
}
