using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddLogFrame1stStepTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogFrame1stStepIndicator",
                columns: table => new
                {
                    LogFrame1stStepIndicatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectGoal = table.Column<string>(maxLength: 255, nullable: true),
                    ResultBaseIndicator = table.Column<string>(maxLength: 255, nullable: true),
                    Outcome = table.Column<string>(maxLength: 255, nullable: true),
                    OutcomeBaseIndicator = table.Column<string>(maxLength: 255, nullable: true),
                    BaselineValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TargetValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    AchieveValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MeasuringUnit = table.Column<string>(maxLength: 50, nullable: true),
                    BaselineDate = table.Column<DateTime>(type: "date", nullable: false),
                    Date1 = table.Column<DateTime>(type: "date", nullable: false),
                    Date2 = table.Column<DateTime>(type: "date", nullable: false),
                    Frequency1 = table.Column<string>(maxLength: 50, nullable: true),
                    Frequency2 = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Participants = table.Column<string>(maxLength: 50, nullable: true),
                    PrimarySource = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame1stStepIndicator", x => x.LogFrame1stStepIndicatorId);
                    table.ForeignKey(
                        name: "FK_LogFrame1stStepIndicator_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame1stStepIndicator_ProjectId",
                table: "LogFrame1stStepIndicator",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrame1stStepIndicator");
        }
    }
}
