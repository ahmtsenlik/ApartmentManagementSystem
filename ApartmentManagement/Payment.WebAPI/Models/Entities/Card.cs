using Payment.WebAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebAPI.Models.Entities
{
    [BsonCollection("Cards")]
    public class Card:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int SecurityCode { get; set; }
        public double Balance { get; set; }
    }
}
