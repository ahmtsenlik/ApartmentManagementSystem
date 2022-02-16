using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentManagement.Infrastructure.Migrations
{
    public partial class updateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Apartments_ApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Apartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_UserId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApartmentId",
                table: "AspNetUsers",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Apartments_ApartmentId",
                table: "AspNetUsers",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
