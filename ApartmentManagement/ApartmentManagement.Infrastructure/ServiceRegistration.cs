using ApartmentManagement.Application.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons;
using ApartmentManagement.Application.Contracts.Persistence.Repositories.Messages;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Apartments;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Bills;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using ApartmentManagement.Infrastructure.Contracts.Persistence.Repositories.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
