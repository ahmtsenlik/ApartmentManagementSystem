using ApartmentManagementClient.Models.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Services.Abstractions
{
    public interface IBillService
    {
        Task<List<GetBillViewModel>> GetBillByUserId();
        Task<List<GetBillViewModel>> GetAllBills();
    }
}
