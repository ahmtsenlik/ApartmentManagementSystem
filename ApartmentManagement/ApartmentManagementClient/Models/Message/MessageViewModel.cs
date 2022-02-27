using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementClient.Models.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public MessageUserModel Sender { get; set; }
        public MessageUserModel Receiver { get; set; }
    }
}
