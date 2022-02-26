using ApartmentManagementClient.Extensions;
using ApartmentManagementClient.Models.Aparments;
using ApartmentManagementClient.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Services.Implementations
{
    public class ApartmentService : IApartmentService
    {
        private readonly HttpClient _client;

        public ApartmentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<GetApartmentViewModel> GetApartmentByUserId()
        {
            var response = await _client.GetAsync($"/api/Apartments/User");
            return await response.ReadContentAs<GetApartmentViewModel>();
        }
        public async Task<List<GetApartmentViewModel>> GetAllApartments()
        {
            var response = await _client.GetAsync($"/api/Apartments/List");
            return await response.ReadContentAs<List<GetApartmentViewModel>>();
        }

    } 
}
