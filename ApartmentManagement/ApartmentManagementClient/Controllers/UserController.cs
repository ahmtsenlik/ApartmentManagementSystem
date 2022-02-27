using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Controllers
{
    public class UserController : Controller
    {
        HttpClient _client;

        public UserController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
   

            HttpResponseMessage response =await _client.GetAsync("/api/Users/List");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(result);

            }
            return View(users);
        }  
        public async Task<IActionResult> Create(UserSignUpModel user)
        {

            var response = await _client.PostAsJsonAsync<UserSignUpModel>("api/Users/Register", user);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ViewData["ErrorMessage"] = Validation(response);
            ViewData["Password"] = "User Password: User*123";
            return View();

        }
        public async Task<IActionResult> Edit(UserUpdateModel user)
        {
            var response = await _client.PutAsJsonAsync<UserUpdateModel>("api/Users", user);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewData["ErrorMessage"] = Validation(response);

            return View();
        }
        public async Task<IActionResult> Delete(int Id)
        {

            var response = await _client.DeleteAsync($"api/Users/{Id}");

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
