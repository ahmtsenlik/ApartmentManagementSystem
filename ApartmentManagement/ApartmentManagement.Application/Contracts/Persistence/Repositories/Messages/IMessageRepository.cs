using ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons;
using ApartmentManagement.Domain.Entities;

namespace ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
    }
}
