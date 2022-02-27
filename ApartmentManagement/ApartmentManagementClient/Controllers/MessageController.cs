using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Message;
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
    public class MessageController : Controller
    {

        HttpClient _client;

        public MessageController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }
        public async Task<IActionResult> Index()
        {
            List<MessageViewModel> messages = new List<MessageViewModel>();


            HttpResponseMessage response = await _client.GetAsync("/api/Messages/User");
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                messages = JsonConvert.DeserializeObject<List<MessageViewModel>>(result);
            }
            return View(messages);
        }
        public async Task<IActionResult> Details(int Id)
        {
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
