using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Models.Bills
{
    public class Apartment
    {
        public bool IsEmpty { get; set; }
        public string Block { get; set; }
        public int No { get; set; }
        public UserViewModel User { get; set; }
    }
}
