using ApartmentManagementClient.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ApartmentManagementClient.Controllers
{
    public class LoginController : Controller
    {
        HttpClient _client;

        public LoginController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (accessToken is not null)
            {
                HttpContext.Session.Clear();
                
                return Redirect("Home");
            }

            var response = await _client.PostAsJsonAsync<LoginModel>("api/Auth/Login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var token = response.Content.ReadAsStringAsync().Result;
                HttpContext.Session.SetString("JWToken", token);
                return Redirect("Home");

            }
            if (response.IsSuccessStatusCode)
            {
                ViewData["ErrorMessage"] = "Incorrect UserName or Password!";
            }
         

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
