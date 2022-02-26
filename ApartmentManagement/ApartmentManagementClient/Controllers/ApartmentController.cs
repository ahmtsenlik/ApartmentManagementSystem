using ApartmentManagementClient.Helper;
using ApartmentManagementClient.Models.Apartments;
using Microsoft.AspNetCore.Http;
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
    public class ApartmentController : Controller
    {
        Api _api=new Api();

        public IActionResult Index()
        {
            List<ApartmentViewModel> apartments = new List<ApartmentViewModel>();
            HttpClient _client = _api.Initial();

            HttpResponseMessage response = _client.GetAsync("/api/Apartments/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                apartments = JsonConvert.DeserializeObject<List<ApartmentViewModel>>(result);
               
            }
            return View(apartments);
        }
        public ActionResult Details(int Id)
        {
            var apartment = new ApartmentDetailViewModel();
            HttpClient _client = _api.Initial();
            HttpResponseMessage response =_client.GetAsync($"/api/Apartments/{Id}").Result;
            
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                apartment = JsonConvert.DeserializeObject<ApartmentDetailViewModel>(result);
                return View(apartment);
            }
            return View(apartment);
        }
        public ActionResult Create(CreateApartmentModel apartment)
        {
            
            HttpClient _client = _api.Initial();
            var addApartment = _client.PostAsJsonAsync<CreateApartmentModel>("api/Apartments", apartment);
            addApartment.Wait();

            var result = addApartment.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            Validation(result);
            
            return View();
        }
        public ActionResult Edit(CreateApartmentModel apartment)
        {

            HttpClient _client = _api.Initial();
            var editApartment = _client.PutAsJsonAsync<CreateApartmentModel>("api/Apartments", apartment);
            editApartment.Wait();

            var result = editApartment.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            Validation(result);

            return View();
        }
        public ActionResult Delete(int Id)
        {

            HttpClient _client = _api.Initial();
            var deleteApartment = _client.DeleteAsync($"api/Apartments/{Id}");

           
            if (deleteApartment.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            Validation(deleteApartment.Result);
            return View();
        }
        public void Validation (HttpResponseMessage check)
        {
            var httpErrorObject = check.Content.ReadAsStringAsync().Result;

            // Create an anonymous object to use as the template for deserialization:
            var anonymousErrorObject =
                new { message = "", ModelState = new Dictionary<string, string[]>() };

            // Deserialize:
            var deserializedErrorObject =
                JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);

            ModelState.AddModelError("", deserializedErrorObject.message.ToString());

        }
    }
}
