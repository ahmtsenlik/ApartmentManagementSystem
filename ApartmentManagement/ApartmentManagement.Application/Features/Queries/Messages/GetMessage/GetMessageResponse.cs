using ApartmentManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public MessageUserModel Sender { get; set; }
        public MessageUserModel Receiver { get; set; }
    }
}
