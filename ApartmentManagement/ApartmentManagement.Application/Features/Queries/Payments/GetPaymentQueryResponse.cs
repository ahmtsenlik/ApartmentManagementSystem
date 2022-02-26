using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Payments
{
    public class GetPaymentQueryResponse
    {
        public string Message { get; set; }
        public bool IsPaid { get; set; }
    }
}
