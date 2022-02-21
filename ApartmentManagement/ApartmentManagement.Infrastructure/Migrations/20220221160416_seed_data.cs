using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentManagement.Infrastructure.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9174cb1f-9855-430f-bf26-03136ae2b538", "AQAAAAEAACcQAAAAEBZNc2qq1NMoLyWXeffkePI2uv268leYBUxpT9pIHV9aj8G+zYdWviWTTX+13ayb6Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "caabb415-fa52-4b89-99fe-d7fe36d7327d", "AQAAAAEAACcQAAAAENJ8uhop6PeAWdbhxMn+lvStVZh65ZhkytAOUvfam3cDE9C9+cBUP4NxYoUfO74ckg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "396ec3c8-f8a3-4d5a-9085-645ed8a7d368", "AQAAAAEAACcQAAAAEIKJXaI26rcToBw8B1ntLB+5N+9iWe7fimfYGInj0sHbMwLiGZd0OYmUaJ3y/Fkciw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07ee5c5b-2ea4-470d-ab46-f38da5421cff", "AQAAAAEAACcQAAAAENae1Nwz9IJc3O974MDNil25oElDxEVw2Q3KrzNRzHudy6SU1aeJMyiLc13bB+rvhQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "963ee642-5a3b-485a-b9ce-5644f3b4a199", "AQAAAAEAACcQAAAAEGJ0L7NNd10LGGLjh8/VWWbLT5MqqVTql2s9KVGHj/Z07LgM9TcfMaVwnMzptFDnwg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a74cfa97-93f6-4f6f-9047-35c9a997d9ea", "AQAAAAEAACcQAAAAEMlVeAr1PuRELKhyMC9rBnF1ocqaewartmLNCP8LsbMc8+nakZnod+ANoDpDtzTDxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "74af8b10-bae8-4681-bfd5-da14e29c30d7", "AQAAAAEAACcQAAAAEEYLS/d/apXRHHRaOIuQu5XDqMS/Eg7jOnVw89s3izl6D7w0qYLjRIxXMdCXR+877w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3774404-4b5c-40c4-bc0f-132e4a148f18", "AQAAAAEAACcQAAAAEL77ERdIDDCliF79mMqVWWdgDxSg2HIz/b70wJLPSTuVYe+OtBCz246fTnQPcAmetw==" });
        }
    }
}
