using ApartmentManagement.Domain.Common;
using System;

namespace ApartmentManagement.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }

    }
}
