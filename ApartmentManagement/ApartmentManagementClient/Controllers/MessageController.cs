using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Controllers
{
    public class MessageController : Controller
    {

        HttpClient _client;

        public MessageController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }
        public async Task<IActionResult> Index()
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            #endregion

            List<MessageViewModel> messages = new List<MessageViewModel>();

            HttpResponseMessage response = await _client.GetAsync("/api/Messages/User");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                messages = JsonConvert.DeserializeObject<List<MessageViewModel>>(result);
            }
            return View(messages);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            #endregion

            var response = await _client.DeleteAsync($"api/Messages/{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> Details(int Id)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            #endregion

            var message = new MessageDetailViewModel();

            HttpResponseMessage response = await _client.GetAsync($"/api/Messages/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                message = JsonConvert.DeserializeObject<MessageDetailViewModel>(result);
                return View(message);
            }

            return View(message);

        }
        public async Task<IActionResult> Create(CreateMessageModel message)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            #endregion
            var response = await _client.PostAsJsonAsync<CreateMessageModel>("api/Messages", message);

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
