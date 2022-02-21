using ApartmentManagement.Application.Models;
using ApartmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessagesResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public MessageUserModel Sender { get; set; }
        public MessageUserModel Receiver { get; set; }
    }
}
