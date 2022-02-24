using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;


namespace ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Apartments
{
    public class ApartmentRepository : BaseRepository<Apartment>,IApartmentRepository
    {
        public ApartmentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
