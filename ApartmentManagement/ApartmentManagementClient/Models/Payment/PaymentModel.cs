using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Models.Payment
{
    public class PaymentModel
    {
        public int BillId { get; set; }
        public int UserId { get; set; }
        [CreditCard]
        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int SecurityCode { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Guid { get; set; }
    }
}
