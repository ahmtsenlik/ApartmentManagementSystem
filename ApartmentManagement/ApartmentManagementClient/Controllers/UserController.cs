using ApartmentManagementClient.Helper;
using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Users;
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
    public class UserController : Controller
    {
        HttpClient _client;

        public UserController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }

        public IActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
   

            HttpResponseMessage response = _client.GetAsync("/api/Users/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(result);

            }
            return View(users);
        }
   
        public ActionResult Create(UserSignUpModel user)
        {

            var addUser = _client.PostAsJsonAsync<UserSignUpModel>("api/Users/Register", user);
            addUser.Wait();

            var result = addUser.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
               Validation(result);
            return View();
        }
        public async Task<ActionResult> Edit(UserUpdateModel user)
        {

            var editUser = await _client.PutAsJsonAsync<UserUpdateModel>("api/Users", user);
            
            if (editUser.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            Validation(editUser);

            return View();
        }
        public ActionResult Delete(int Id)
        {

            var deleteUser = _client.DeleteAsync($"api/Users/{Id}");

            if (deleteUser.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            Validation(deleteUser.Result);
            return View();
        }
        public void Validation(HttpResponseMessage check)
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
