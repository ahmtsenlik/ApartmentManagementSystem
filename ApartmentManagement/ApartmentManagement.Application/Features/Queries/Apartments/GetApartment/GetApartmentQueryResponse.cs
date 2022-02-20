using ApartmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryResponse
    {
        public bool IsEmpty { get; set; }
        public string Block { get; set; }
        public int No { get; set; }
        public string NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public bool IsOwner { get; set; }
        public ApartmentUser User { get; set; }

    
    }
    public class ApartmentUser
    {
        public string TCIdentityNumber { get; set; }
        public string FullName { get; set; }
        public string LicensePlate { get; set; }    
        public bool IsActive { get; set; }

    }
}
