using ApartmentManagement.Domain.Common;
using System;

namespace ApartmentManagement.Domain.Entities
{
    public class Payment:BaseEntity
    {
        public int BillId { get; set; }
        public string Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPaid { get; set; }

    }
}
