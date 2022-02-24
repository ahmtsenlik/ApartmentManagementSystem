using ApartmentManagement.Application.Models;
using System;

namespace ApartmentManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessagesResponse
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
