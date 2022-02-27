using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Models.Bills
{
    public class ApartmentListBillBulkModel
    {
        public int Select { get; set; }
        public int Id { get; set; }
        public bool IsEmpty { get; set; }
        public string Block { get; set; }
        public int No { get; set; }
        public string NumberOfRooms { get; set; }
        public int Floor { get; set; }
    }
}
