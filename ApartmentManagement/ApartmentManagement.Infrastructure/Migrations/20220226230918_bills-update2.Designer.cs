﻿// <auto-generated />
using System;
using ApartmentManagement.Infrastructure.Contracts.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApartmentManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220226230918_bills-update2")]
    partial class billsupdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsEmpty")
                        .HasColumnType("bit");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<string>("NumberOfRooms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Block = "A",
                            Floor = 1,
                            IsEmpty = true,
                            No = 1,
                            NumberOfRooms = "3+1"
                        },
                        new
                        {
                            Id = 2,
                            Block = "A",
                            Floor = 2,
                            IsEmpty = true,
                            No = 4,
                            NumberOfRooms = "4+1"
                        },
                        new
                        {
                            Id = 3,
                            Block = "B",
                            Floor = 4,
                            IsEmpty = true,
                            No = 11,
                            NumberOfRooms = "3+1"
                        },
                        new
                        {
                            Id = 4,
                            Block = "C2",
                            Floor = 2,
                            IsEmpty = true,
                            No = 5,
                            NumberOfRooms = "2+1"
                        });
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int?>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCIdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "02e380bb-b1f7-4113-918f-7fdfe4ffae92",
                            Email = "ahmtsenlik@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ahmet",
                            IsOwner = false,
                            LastName = "Şenlik",
                            LicensePlate = "41 YZ 299",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDFuK5wcIbrm3sHmICcBWJCgRU++1YNpPqGGXKgLfDPPdtSelEg29ojBDK/SCq5RuA==",
                            PhoneNumber = "05369102782",
                            PhoneNumberConfirmed = false,
                            TCIdentityNumber = "16597722874",
                            TwoFactorEnabled = false,
                            UserName = "ahmetsenlik"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d687c5dc-d0f8-4664-b9e3-9a75555f7c75",
                            Email = "erdidemir@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Erdi",
                            IsOwner = false,
                            LastName = "Demir",
                            LicensePlate = "06 EF 184",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEEPJVABEWPTSjRSWzFLnFkA36UjsC2SY4dJAaEMUKyCPXvFNq6jGeHX9TPYZnqH/gg==",
                            PhoneNumber = "05369448796",
                            PhoneNumberConfirmed = false,
                            TCIdentityNumber = "12697864166",
                            TwoFactorEnabled = false,
                            UserName = "erdidemir"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b31b48f3-173c-4a94-85a6-b92cdb1b8a7c",
                            Email = "selimaydin@hotmail.com",
                            EmailConfirmed = false,
                            FirstName = "Selim",
                            IsOwner = false,
                            LastName = "Aydın",
                            LicensePlate = "34 KM 9514",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAENAMY5KkJ+MebM/hZ++OF/ZDyGovL7t4/5VdH7MgL90laphlFEzRxxoe6zwKl14+dg==",
                            PhoneNumber = "05058971123",
                            PhoneNumberConfirmed = false,
                            TCIdentityNumber = "32548764166",
                            TwoFactorEnabled = false,
                            UserName = "selimaydin"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4aa6cca1-5875-4841-b448-3d4f90dcf787",
                            Email = "feyzademir@hotmail.com",
                            EmailConfirmed = false,
                            FirstName = "Feyza",
                            IsOwner = false,
                            LastName = "Demir",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEAlWaCK/NZJrKZ07gll5C7ZQfWQSjVoaNIV783o5vcS9thFvJMsEV2y0h9AOwOsOmg==",
                            PhoneNumber = "05426179925",
                            PhoneNumberConfirmed = false,
                            TCIdentityNumber = "79211961462",
                            TwoFactorEnabled = false,
                            UserName = "feyzademir"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Apartment", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.User", "User")
                        .WithOne("Apartment")
                        .HasForeignKey("ApartmentManagement.Domain.Entities.Apartment", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Bill", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.Apartment", "Apartment")
                        .WithMany("Bills")
                        .HasForeignKey("ApartmentId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Message", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.User", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("ApartmentManagement.Domain.Entities.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartmentManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ApartmentManagement.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.Apartment", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("ApartmentManagement.Domain.Entities.User", b =>
                {
                    b.Navigation("Apartment");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
