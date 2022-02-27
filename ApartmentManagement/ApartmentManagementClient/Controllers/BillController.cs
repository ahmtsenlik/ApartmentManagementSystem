using ApartmentManagementClient.Models.Bills;
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
    public class BillController : Controller
    {

        HttpClient _client;

        public BillController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }
        public async Task<IActionResult> Index(bool? isPaid)
        {
            List<BillViewModel> apartments = new List<BillViewModel>();


            HttpResponseMessage response = await _client.GetAsync($"/api/Bills/List{isPaid}");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                apartments = JsonConvert.DeserializeObject<List<BillViewModel>>(result);
            }
            return View(apartments);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var bill = new BillDetailViewModel();

            HttpResponseMessage response = await  _client.GetAsync($"/api/Bills/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                bill = JsonConvert.DeserializeObject<BillDetailViewModel>(result);

                return View(bill);
            }
            return View(bill);

        }
        public async Task<IActionResult> Create(CreateBillModel apartment)
        {

            var response =await _client.PostAsJsonAsync<CreateBillModel>("api/Bills", apartment);  

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ViewData["ErrorMessage"] = Validation(response);

            return View();
        }
        //public ActionResult Edit(ApartmentViewModel apartment)
        //{

        //    var editApartment = _client.PutAsJsonAsync<ApartmentViewModel>("api/Apartments", apartment);
        //    editApartment.Wait();

        //    var result = editApartment.Result;

        //    if (result.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    Validation(result);

        //    return View();
        //}

        //public ActionResult AddUser(ApartmentViewModel apartment)
        //{

        //    var editApartment = _client.PutAsJsonAsync<ApartmentViewModel>("api/Apartments", apartment);
        //    editApartment.Wait();

        //    var result = editApartment.Result;

        //    if (result.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    Validation(result);

        //    return View();
        //}
        public async Task<IActionResult> Delete(int Id)
        {

            var response= await _client.DeleteAsync($"api/Apartments/{Id}");


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

