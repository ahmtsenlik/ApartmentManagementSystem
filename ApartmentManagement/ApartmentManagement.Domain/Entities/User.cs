using ApartmentManagement.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Domain.Entities
{
    //user yerine resident kullanılır mı
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCIdentityNumber { get; set; }
        public string LicensePlate { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
        [InverseProperty("Sender")]
        public ICollection<Message> SentMessages { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<Message> ReceivedMessages{ get; set; }

    }
}
