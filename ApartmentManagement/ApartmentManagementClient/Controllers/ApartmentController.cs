using ApartmentManagementClient.Models;
using ApartmentManagementClient.Models.Apartments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

            #region Admin

            List<ApartmentViewModel> apartments = new List<ApartmentViewModel>();
            if (findRole=="Admin")
            {
                
                HttpResponseMessage response = await _client.GetAsync("/api/Apartments/List");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    apartments = JsonConvert.DeserializeObject<List<ApartmentViewModel>>(result);
                    return View(apartments);
                }
            }
            #endregion

            #region User

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apartment = new ApartmentViewModel();
         
            HttpResponseMessage responseSingle = await _client.GetAsync($"/api/Apartments/User/{1}");
            if (responseSingle.IsSuccessStatusCode)
            {
                string result = responseSingle.Content.ReadAsStringAsync().Result;
                apartment = JsonConvert.DeserializeObject<ApartmentViewModel>(result);
               
            }
            apartments.Add(apartment);
            return View(apartments);

            #endregion
        }
        public async Task<IActionResult> Details(int Id)
        {
            #region Token
            var accessToken = HttpContext.Session.GetString("JWToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (accessToken is null)
            {
                return Redirect("Home");
            }
            #endregion 

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

            if (findRole == "Admin")
            {

                var response = await _client.PostAsJsonAsync<CreateApartmentModel>("api/Apartments", apartment);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ViewData["ErrorMessage"] = Validation(response);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(ApartmentViewModel apartment)
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
                var response = await _client.PutAsJsonAsync<ApartmentViewModel>("api/Apartments", apartment);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ViewData["ErrorMessage"] = Validation(response);
            }
           
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SelectUser(int id)
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

            if (findRole == "Admin")
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
                    for (int j = 0; j < apartments.Count; j++)
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
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddUser(int userId, int apartmentId)
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
            if (findRole == "Admin")
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
            }
            return RedirectToAction("Index");
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
            if (findRole == "Admin")
            {


                var response = await _client.DeleteAsync($"api/Apartments/{Id}");


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveUser(int id)
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
                var response = await _client.DeleteAsync($"api/Apartments/RemoveUser/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
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
