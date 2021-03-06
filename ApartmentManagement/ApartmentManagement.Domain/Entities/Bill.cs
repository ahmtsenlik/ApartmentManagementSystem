using ApartmentManagement.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static ApartmentManagement.Domain.Enum.BaseEnum;

namespace ApartmentManagement.Domain.Entities
{
    public class Bill:BaseEntity
    {
        public BillType Type { get; set; }
        [Column(TypeName = "money")]
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentTime { get; set; }

        public Apartment Apartment { get; set; } 
    }
}
