using ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Payments;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;

namespace ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Payments
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
