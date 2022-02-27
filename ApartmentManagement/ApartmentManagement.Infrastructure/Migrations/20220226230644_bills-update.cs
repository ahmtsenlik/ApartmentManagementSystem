using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentManagement.Infrastructure.Migrations
{
    public partial class billsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentTime",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentTime",
                table: "Bills");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95a0bc1b-5fbe-45a0-bcf3-17df1cbc06b4", "AQAAAAEAACcQAAAAEKCDTD8RQwLW2UrlTIM2BUOqVARe6BlL18Af/4gImYsApVvMG/CEKmgqjk9CKvCEFg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ba30967-9e6d-455a-9596-ca3139768132", "AQAAAAEAACcQAAAAEC0NT5XNxRaNlkASvygEYlTLvyWfYNCjPRLbhsCqzlnayxgGTFD/QO+NXU6/9JGOkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30eb42d9-44fd-4f01-82ec-7f4661430987", "AQAAAAEAACcQAAAAEDYjs8RF5rTcv22a2r1v23GKm6bwea8kGFtJyFbVxNsUrDpvg9TI/M3Tzw5trUA9XQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6f3a1bd-7dad-46b2-8812-310f9380d534", "AQAAAAEAACcQAAAAELad5zjcJ4tAk6qCw1aagSHI3DLpD2sEKwjleBCAl6fUJMwD0yGKvIw1WCE4rtf/bA==" });
        }
    }
}
