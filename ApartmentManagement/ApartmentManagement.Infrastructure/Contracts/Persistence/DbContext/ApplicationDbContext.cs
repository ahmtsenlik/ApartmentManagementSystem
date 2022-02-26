using ApartmentManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext
{
    public class ApplicationContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
            this.SeedApartments(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>().HasData(
            new User { 
                Id = 1,
                FirstName = "Ahmet",
                LastName = "Şenlik",
                UserName="ahmetsenlik",
                PasswordHash = hasher.HashPassword(null, "User*123"),
                TCIdentityNumber = "16597722874",
                LicensePlate = "41 YZ 299",
                Email = "ahmtsenlik@gmail.com",
                PhoneNumber = "05369102782" 
            },
            new User { 
                Id = 2,
                FirstName = "Erdi",
                LastName = "Demir",
                UserName="erdidemir",
                PasswordHash = hasher.HashPassword(null, "User*123"),
                TCIdentityNumber = "12697864166",
                LicensePlate = "06 EF 184",
                Email = "erdidemir@gmail.com",
                PhoneNumber = "05369448796" 
            },
            new User {
                Id = 3,
                FirstName = "Selim",
                LastName = "Aydın",
                UserName="selimaydin",
                PasswordHash = hasher.HashPassword(null, "User*123"),
                TCIdentityNumber = "32548764166",
                LicensePlate = "34 KM 9514",
                Email = "selimaydin@hotmail.com",
                PhoneNumber = "05058971123" 
            },
            new User { 
                Id = 4,
                FirstName = "Feyza",
                LastName = "Demir",
                UserName="feyzademir",
                PasswordHash = hasher.HashPassword(null, "User*123"),
                TCIdentityNumber = "79211961462",
                Email = "feyzademir@hotmail.com",
                PhoneNumber = "05426179925" 
            }
            );
            
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
            new Role() { Id = 1, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
            new Role() { Id = 2, Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
            );
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int> { RoleId = 1, UserId = 1 },
            new IdentityUserRole<int> { RoleId = 2, UserId = 2 },
            new IdentityUserRole<int> { RoleId = 2, UserId = 3 },
            new IdentityUserRole<int> { RoleId = 2, UserId = 4 }
            );
        }
        private void SeedApartments(ModelBuilder builder)
        {
            builder.Entity<Apartment>().HasData(
            new Apartment { Id = 1, IsEmpty = true, Block = "A", No = 1, NumberOfRooms = "3+1", Floor = 1 },
            new Apartment { Id = 2, IsEmpty = true, Block = "A", No = 4, NumberOfRooms = "4+1", Floor = 2 },
            new Apartment { Id = 3, IsEmpty = true, Block = "B", No = 11, NumberOfRooms = "3+1", Floor = 4 },
            new Apartment { Id = 4, IsEmpty = true, Block = "C2", No = 5, NumberOfRooms = "2+1", Floor = 2 }
            );
        }
    }
}
