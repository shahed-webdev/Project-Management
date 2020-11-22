using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddDataToProjectSectorTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProjectSector",
                columns: new[] { "ProjectSectorId", "Sector" },
                values: new object[,]
                {
                    { 1, "Access to Justice" },
                    { 2, "Activism along the Agricultural, Fishery, Dairy and Horticulture Value Chain" },
                    { 3, "Climate Emergency, Biodiversity and Disaster Management 1" },
                    { 4, "Climate Emergency, Biodiversity and Disaster Management 2" },
                    { 5, "Company as a social entrepreneurship" },
                    { 6, "Health and Nutrition" },
                    { 7, "Microfinance" },
                    { 8, "Youth Development (Education, skill, moral and cultural behavior)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProjectSector",
                keyColumn: "ProjectSectorId",
                keyValue: 8);
        }
    }
}
