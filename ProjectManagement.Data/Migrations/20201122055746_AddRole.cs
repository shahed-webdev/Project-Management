using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F73A5277-2535-48A4-A371-300508ADDD2F");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9E6E9812-4A93-4F28-81F3-8B52181EFA77", "9E6E9812-4A93-4F28-81F3-8B52181EFA77", "ReadOnly", "READONLY" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "B6ED309F-4F39-4862-B488-B27669C202C5", "B6ED309F-4F39-4862-B488-B27669C202C5", "FullExist", "FULLEXIST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9E6E9812-4A93-4F28-81F3-8B52181EFA77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B6ED309F-4F39-4862-B488-B27669C202C5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "F73A5277-2535-48A4-A371-300508ADDD2F", "F73A5277-2535-48A4-A371-300508ADDD2F", "SubAdmin", "SUBADMIN" });
        }
    }
}
