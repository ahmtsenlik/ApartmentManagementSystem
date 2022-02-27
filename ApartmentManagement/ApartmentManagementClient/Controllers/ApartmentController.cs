using ApartmentManagementClient.Models.Apartments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Controllers
{
    public class ApartmentController : Controller
    {
     
        HttpClient _client;

        public ApartmentController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            List<ApartmentViewModel> apartments = new List<ApartmentViewModel>();
            

            HttpResponseMessage response = await _client.GetAsync("/api/Apartments/List");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                apartments = JsonConvert.DeserializeObject<List<ApartmentViewModel>>(result);
               
            }
            return View(apartments);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var apartment = new ApartmentDetailViewModel();
            
            HttpResponseMessage response =await _client.GetAsync($"/api/Apartments/{Id}");
            
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                apartment = JsonConvert.DeserializeObject<ApartmentDetailViewModel>(result);
                return View(apartment);
            }
          
            return View(apartment);
            
        }
        public async Task<IActionResult> Create(CreateApartmentModel apartment)
        {
            
            var response =await _client.PostAsJsonAsync<CreateApartmentModel>("api/Apartments", apartment);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ViewData["ErrorMessage"] = Validation(response);

            return View();
        }
        public async Task<IActionResult> Edit(ApartmentViewModel apartment)
        {
            var response = await _client.PutAsJsonAsync<ApartmentViewModel>("api/Apartments", apartment);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            ViewData["ErrorMessage"]= Validation(response);
            return View();
        }

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
            var response =await _client.DeleteAsync($"api/Apartments/{Id}");
        
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }
        public string Validation (HttpResponseMessage check)
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
