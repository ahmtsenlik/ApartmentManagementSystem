using ApartmentManagementClient.Extensions;
using ApartmentManagementClient.Models.Bills;
using ApartmentManagementClient.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Services.Implementations
{
    public class BillService : IBillService
    {
        private readonly HttpClient _client;

        public BillService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<GetBillViewModel>> GetAllBills()
        {
            var response = await _client.GetAsync($"/api/Bills/List");
            return await response.ReadContentAs<List<GetBillViewModel>>();
        }

        public async Task<List<GetBillViewModel>> GetBillByUserId()
        {
            var response = await _client.GetAsync($"/api/Bills/User");
            return await response.ReadContentAs<List<GetBillViewModel>>();
        }
    }
}