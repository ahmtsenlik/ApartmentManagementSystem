using ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
