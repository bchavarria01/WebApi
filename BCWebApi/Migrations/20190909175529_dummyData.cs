using Microsoft.EntityFrameworkCore.Migrations;

namespace BCWebApi.Migrations
{
    public partial class dummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "UserTypeName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "UserTypeName" },
                values: new object[] { 2, "Customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "UserPassword", "UserTypeId" },
                values: new object[] { 1, "Admin", "root", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "UserPassword", "UserTypeId" },
                values: new object[] { 2, "Armando", "root", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 2);
        }
    }
}
