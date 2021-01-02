using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddProjectCityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_City_CityId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CityId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "TotalBudget",
                table: "Project",
                newName: "TotalBudgetUsd");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DirectIndirectType",
                table: "Project",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonorType",
                table: "Project",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndividualHouseholdType",
                table: "Project",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWord",
                table: "Project",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBudgetBdt",
                table: "Project",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectCity",
                columns: table => new
                {
                    ProjectCityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCity", x => x.ProjectCityId);
                    table.ForeignKey(
                        name: "FK_ProjectCity_City_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_ProjectCity_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCity_ProjectId",
                table: "ProjectCity",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCity");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DirectIndirectType",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DonorType",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IndividualHouseholdType",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KeyWord",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TotalBudgetBdt",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "TotalBudgetUsd",
                table: "Project",
                newName: "TotalBudget");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CityId",
                table: "Project",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_City_CityId",
                table: "Project",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");
        }
    }
}
