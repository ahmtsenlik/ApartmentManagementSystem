using ApartmentManagementClient.Models.Apartments;
using ApartmentManagementClient.Models.Bills;
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
    public class BillController : Controller
    {

        HttpClient _client;

        public BillController(IHttpClientFactory client)
        {
            _client = client.CreateClient("api");
        }
        public async Task<IActionResult> Index(bool? isPaid)
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

            List<BillViewModel> bills = new List<BillViewModel>();

            #region Admin
            
            if (findRole=="Admin")
            {
                HttpResponseMessage response = await _client.GetAsync($"/api/Bills/List?isPaid={isPaid}");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    bills = JsonConvert.DeserializeObject<List<BillViewModel>>(result);
                }
                return View(bills);
            }
            #endregion

            #region User
            HttpResponseMessage responseSingle = await _client.GetAsync($"/api/Bills/User/{1}");
            if (responseSingle.IsSuccessStatusCode)
            {
                string result = responseSingle.Content.ReadAsStringAsync().Result;
                bills = JsonConvert.DeserializeObject<List<BillViewModel>>(result);
            }
            return View(bills);
            #endregion
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

            var bill = new BillDetailViewModel();

            HttpResponseMessage response = await  _client.GetAsync($"/api/Bills/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                bill = JsonConvert.DeserializeObject<BillDetailViewModel>(result);

                return View(bill);
            }
            return View(bill);

        }
        public async Task<IActionResult> Create(CreateBillModel bill)
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
                var response = await _client.PostAsJsonAsync<CreateBillModel>("api/Bills", bill);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ViewData["ErrorMessage"] = Validation(response);
            }



            return RedirectToAction("Index");
        }  

        //public async Task<IActionResult> CreateBulk(CreateBillModel bill)
        //{

        //    var response = await _client.PostAsJsonAsync<CreateBillModel>("api/Bills", bill);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["ErrorMessage"] = Validation(response);

        //    return View();
        //}
   
  
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

