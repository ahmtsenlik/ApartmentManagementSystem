using ApartmentManagementClient.Models.Login;
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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        HttpClient _client;

        public LoginController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }

        public ActionResult Login(LoginModel loginModel)
        {

            var loginResponse = _client.PutAsJsonAsync<LoginModel>("api/Auth/Login", loginModel);

     

            //if (loginResponse.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //Validation(loginResponse);

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
