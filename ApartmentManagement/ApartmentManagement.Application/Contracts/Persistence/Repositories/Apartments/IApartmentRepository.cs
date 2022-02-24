using ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons;
using ApartmentManagement.Domain.Entities;

namespace ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments
{
    public interface IApartmentRepository : IBaseRepository<Apartment>
    {
    }
}
