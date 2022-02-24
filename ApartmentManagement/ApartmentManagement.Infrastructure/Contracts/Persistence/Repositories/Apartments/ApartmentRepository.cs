using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Apartments
{
    public class ApartmentRepository : BaseRepository<Apartment>,IApartmentRepository
    {
        public ApartmentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
