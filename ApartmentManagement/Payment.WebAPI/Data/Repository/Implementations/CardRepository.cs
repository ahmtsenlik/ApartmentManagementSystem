using Payment.WebAPI.Data.Repository.Abstractions;
using Payment.WebAPI.Models;
using Payment.WebAPI.Models.Entities;
using Payment.WebAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebAPI.Data.Repository.Implementations
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}
