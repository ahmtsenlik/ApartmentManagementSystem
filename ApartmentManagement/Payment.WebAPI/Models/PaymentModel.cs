using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebAPI.Models
{
    public class PaymentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int SecurityCode { get; set; }
    }
}
