
using System;

namespace ApartmentManagement.Application.Features.Queries.Payments.GetPayments
{
    public class GetPaymentsQueryResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int BillId { get; set; }
        public bool IsPaid { get; set; }

    }
}
