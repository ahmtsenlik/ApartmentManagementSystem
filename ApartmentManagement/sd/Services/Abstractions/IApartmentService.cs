using ApartmentManagementClient.Models.Aparments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Services.Abstractions
{
    public interface IApartmentService
    {
        Task<GetApartmentViewModel> GetApartmentByUserId();
        Task<List<GetApartmentViewModel>> GetAllApartments();
    }
}
