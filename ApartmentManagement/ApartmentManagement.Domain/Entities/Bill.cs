using ApartmentManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Domain.Entities
{
    public class Bill:BaseEntity
    {
        public string BillType { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsPaid { get; set; }

        public Apartment Apartment { get; set; } 
    }
}
