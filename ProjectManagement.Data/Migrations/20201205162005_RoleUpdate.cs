using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class RoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B6ED309F-4F39-4862-B488-B27669C202C5",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "FullAccess", "FULLACCESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B6ED309F-4F39-4862-B488-B27669C202C5",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "FullExist", "FULLEXIST" });
        }
    }
}
