using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentManagement.Infrastructure.Migrations
{
    public partial class billsupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentTime",
                table: "Bills",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02e380bb-b1f7-4113-918f-7fdfe4ffae92", "AQAAAAEAACcQAAAAEDFuK5wcIbrm3sHmICcBWJCgRU++1YNpPqGGXKgLfDPPdtSelEg29ojBDK/SCq5RuA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d687c5dc-d0f8-4664-b9e3-9a75555f7c75", "AQAAAAEAACcQAAAAEEPJVABEWPTSjRSWzFLnFkA36UjsC2SY4dJAaEMUKyCPXvFNq6jGeHX9TPYZnqH/gg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b31b48f3-173c-4a94-85a6-b92cdb1b8a7c", "AQAAAAEAACcQAAAAENAMY5KkJ+MebM/hZ++OF/ZDyGovL7t4/5VdH7MgL90laphlFEzRxxoe6zwKl14+dg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4aa6cca1-5875-4841-b448-3d4f90dcf787", "AQAAAAEAACcQAAAAEAlWaCK/NZJrKZ07gll5C7ZQfWQSjVoaNIV783o5vcS9thFvJMsEV2y0h9AOwOsOmg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentTime",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b22e062-9a1a-4adf-be6b-fac4e992550c", "AQAAAAEAACcQAAAAEOsqI1F0XaKgdXrOTJJcREjrDwVndSu90vAoxzWigmXEdQ3nuHdazrBh2bbo1x+f+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a835bb63-98ae-4de3-b88b-0ec68a7f52e1", "AQAAAAEAACcQAAAAEM5jZj7FoLdqQX29cbftB1n+xxjKyCNzgdQeQIvTkcuBmzC3TbhnFQmXiVxf100OlQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71b9a660-e49c-4173-9536-f34e0f417c7e", "AQAAAAEAACcQAAAAEJNrBeuab3nkl/5ATF702fpdwz2frltoEeJ48tygReP15m1685PiTn+1qDpsnXQVJQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4b5e4d0-53f4-43c8-ad36-9d97b5f9e1af", "AQAAAAEAACcQAAAAEHYXgbpdWuC+Ur8LVt8/3cg3dcfhHt3yrlm9c8JXIXJYOwXrAOMBIIu8ROczZL291g==" });
        }
    }
}
