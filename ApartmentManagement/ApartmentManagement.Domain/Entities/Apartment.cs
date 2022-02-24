using ApartmentManagement.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagement.Domain.Entities
{
    public class Apartment:BaseEntity
    {
        public bool IsEmpty { get; set; }
        public string Block { get; set; }
        public int No { get; set; }
        public string NumberOfRooms { get; set; }
        public int Floor { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
    