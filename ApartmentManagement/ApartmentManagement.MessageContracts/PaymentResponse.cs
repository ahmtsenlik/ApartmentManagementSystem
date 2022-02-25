using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.MessageContracts
{
    public class PaymentResponse
    {
        public bool IsPaid { get; set; }
        public int UserId { get; set; }
    }
}
