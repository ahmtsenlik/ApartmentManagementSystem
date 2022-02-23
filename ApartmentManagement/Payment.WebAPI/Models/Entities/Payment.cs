using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebAPI.Models.Entities
{
    public class Payment:BaseEntity
    {
        public int MyProperty { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

    }
}
