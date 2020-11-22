using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddSectorInRegistrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectSectorId",
                table: "Registration",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_ProjectSectorId",
                table: "Registration",
                column: "ProjectSectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_ProjectSector_ProjectSectorId",
                table: "Registration",
                column: "ProjectSectorId",
                principalTable: "ProjectSector",
                principalColumn: "ProjectSectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_ProjectSector_ProjectSectorId",
                table: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Registration_ProjectSectorId",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "ProjectSectorId",
                table: "Registration");
        }
    }
}
