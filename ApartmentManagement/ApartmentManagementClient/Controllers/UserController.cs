using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);

            var findRole = jwtSecurityToken.Claims.First(x => x.Value == "Admin" || x.Value == "User").Value;

            #endregion

            List<UserViewModel> users = new List<UserViewModel>();

            #region Admin
            if (findRole=="Admin")
            {
                HttpResponseMessage response = await _client.GetAsync("/api/Users/List");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(result);

                }
                return View(users);
            }
            #endregion

            #region User
            var user = new UserViewModel();
            HttpResponseMessage responseSingle =await _client.GetAsync($"/api/Users/{1}");
            if (responseSingle.IsSuccessStatusCode)
            {
                string result = responseSingle.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserViewModel>(result);

            }
             
            users.Add(user);
            return View(users);
            #endregion
        }
        public async Task<IActionResult> Create(UserSignUpModel user)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);

            var findRole = jwtSecurityToken.Claims.First(x => x.Value == "Admin" || x.Value == "User").Value;
           
            #endregion
            if (findRole=="Admin")
            {
                var response = await _client.PostAsJsonAsync<UserSignUpModel>("api/Users/Register", user);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ViewData["ErrorMessage"] = Validation(response);
                ViewData["Password"] = "User Password: User*123";
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();

        }
        public async Task<IActionResult> Edit(UserUpdateModel user)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);

            var findRole = jwtSecurityToken.Claims.First(x => x.Value == "Admin" || x.Value == "User").Value;

            #endregion
            if (findRole=="Admin")
            {
                var response = await _client.PutAsJsonAsync<UserUpdateModel>("api/Users", user);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ViewData["ErrorMessage"] = Validation(response);

            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();
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

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(accessToken);

            var findRole = jwtSecurityToken.Claims.First(x => x.Value == "Admin" || x.Value == "User").Value;

            #endregion
            if (findRole=="Admin")
            {
                var response = await _client.DeleteAsync($"api/Users/{Id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ViewData["ErrorMessage"] = Validation(response);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();


        }

        public async Task<IActionResult> ChangePassword(ChangePassModel changePass)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            #endregion  

            var response = await _client.PutAsJsonAsync<ChangePassModel>("api/Users/ChangePass", changePass);
            ViewData["ErrorMessage"] = Validation(response);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
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
