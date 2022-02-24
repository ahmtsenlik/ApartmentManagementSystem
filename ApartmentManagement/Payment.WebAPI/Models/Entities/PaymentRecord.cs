using Payment.WebAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebAPI.Models.Entities
{
    [BsonCollection("PaymentRecords")]
    public class PaymentRecord:BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsSuccess { get; set; }
    }
}
