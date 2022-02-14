using ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons;
using ApartmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
    }
}
