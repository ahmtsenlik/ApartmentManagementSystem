using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Models.Bills
{
    public class CreateBulkBill
    {

        public string Type { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IList<int> Apartments { get; set; }
    }
}
