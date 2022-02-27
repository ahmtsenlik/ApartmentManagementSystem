using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Apartments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
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

        public async Task<IActionResult> SelectUser(int id)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            HttpResponseMessage responseUser = await _client.GetAsync("/api/Users/List");
            if (responseUser.IsSuccessStatusCode)
            {
                string result = responseUser.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(result);
                
            }

            List<ApartmentDetailViewModel> apartments = new List<ApartmentDetailViewModel>();
            HttpResponseMessage responseApartment = await _client.GetAsync("/api/Apartments/List");
            if (responseApartment.IsSuccessStatusCode)
            {
                string result = responseApartment.Content.ReadAsStringAsync().Result;
                apartments = JsonConvert.DeserializeObject<List<ApartmentDetailViewModel>>(result);
            }
            List<UserViewModel> removeUser = new List<UserViewModel>();
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j<apartments.Count ; j++)
                {
                    if (apartments[j].User is not null)
                    {
                        if (users[i].Id == apartments[j].User.Id)
                        {
                            removeUser.Add(users[i]);
                        }
                    }                  
                }                
            }
            for (int i = 0; i < removeUser.Count; i++)
            {
                users.Remove(removeUser[i]);
            }
            ViewData["Id"] = id;
            return View(users);
        }
        public async Task<IActionResult> AddUser(int userId, int apartmentId)
        {
            AddUserModel addUserModel = new AddUserModel();
            addUserModel.ApartmentId = apartmentId;
            addUserModel.UserId = userId;
            var response = await _client.PutAsJsonAsync<AddUserModel>("api/Apartments/AddUser", addUserModel);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewData["ErrorMessage"] = Validation(response);
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
       
            var response =await _client.DeleteAsync($"api/Apartments/{Id}");

           
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }
        public async Task<IActionResult> RemoveUser(int id)
        {

            var response = await _client.DeleteAsync($"api/Apartments/RemoveUser/{id}");


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
