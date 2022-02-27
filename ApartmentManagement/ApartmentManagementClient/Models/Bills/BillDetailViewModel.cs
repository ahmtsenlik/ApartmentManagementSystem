using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Models.Bills
{
    public class BillDetailViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsPaid { get; set; }
        public Apartment Apartment { get; set; }
        

    }
}
