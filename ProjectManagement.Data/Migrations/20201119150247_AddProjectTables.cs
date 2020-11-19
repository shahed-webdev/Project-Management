using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddProjectTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    DonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.DonorId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectBeneficiaryType",
                columns: table => new
                {
                    ProjectBeneficiaryTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryType = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBeneficiaryType", x => x.ProjectBeneficiaryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSector",
                columns: table => new
                {
                    ProjectSectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSector", x => x.ProjectSectorId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    ProjectStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.ProjectStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ReportType",
                columns: table => new
                {
                    ReportTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportType", x => x.ReportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    StateName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectSectorId = table.Column<int>(nullable: false),
                    ProjectStatusId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 225, nullable: false),
                    ProjectName = table.Column<string>(maxLength: 225, nullable: false),
                    ReportName = table.Column<string>(maxLength: 225, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalBudget = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalExpenditure = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Project_ProjectSector_ProjectSectorId",
                        column: x => x.ProjectSectorId,
                        principalTable: "ProjectSector",
                        principalColumn: "ProjectSectorId");
                    table.ForeignKey(
                        name: "FK_Project_ProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatus",
                        principalColumn: "ProjectStatusId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectBeneficiary",
                columns: table => new
                {
                    ProjectBeneficiaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectBeneficiaryTypeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBeneficiary", x => x.ProjectBeneficiaryId);
                    table.ForeignKey(
                        name: "FK_ProjectBeneficiary_ProjectBeneficiaryType_ProjectBeneficiaryTypeId",
                        column: x => x.ProjectBeneficiaryTypeId,
                        principalTable: "ProjectBeneficiaryType",
                        principalColumn: "ProjectBeneficiaryTypeId");
                    table.ForeignKey(
                        name: "FK_ProjectBeneficiary_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDonor",
                columns: table => new
                {
                    ProjectDonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    DonorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDonor", x => x.ProjectDonorId);
                    table.ForeignKey(
                        name: "FK_ProjectDonor_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "DonorId");
                    table.ForeignKey(
                        name: "FK_ProjectDonor_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectReports",
                columns: table => new
                {
                    ProjectReportsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportTypeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 128, nullable: false),
                    FileUrl = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReports", x => x.ProjectReportsId);
                    table.ForeignKey(
                        name: "FK_ProjectReports_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectReports_ReportType_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportType",
                        principalColumn: "ReportTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CityId",
                table: "Project",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectSectorId",
                table: "Project",
                column: "ProjectSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBeneficiary_ProjectBeneficiaryTypeId",
                table: "ProjectBeneficiary",
                column: "ProjectBeneficiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBeneficiary_ProjectId",
                table: "ProjectBeneficiary",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDonor_DonorId",
                table: "ProjectDonor",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDonor_ProjectId",
                table: "ProjectDonor",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReports_ProjectId",
                table: "ProjectReports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReports_ReportTypeId",
                table: "ProjectReports",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBeneficiary");

            migrationBuilder.DropTable(
                name: "ProjectDonor");

            migrationBuilder.DropTable(
                name: "ProjectReports");

            migrationBuilder.DropTable(
                name: "ProjectBeneficiaryType");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ReportType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ProjectSector");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
