using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Bills
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
