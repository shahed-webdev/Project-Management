using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class LogFrameStep2and3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date2",
                table: "LogFrame1stStepIndicator",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date1",
                table: "LogFrame1stStepIndicator",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaselineDate",
                table: "LogFrame1stStepIndicator",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "LogFrame2ndStepOutput",
                columns: table => new
                {
                    LogFrame2ndStepOutputId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    Output = table.Column<string>(maxLength: 255, nullable: true),
                    OutputBaseIndicator = table.Column<string>(maxLength: 255, nullable: true),
                    BaselineValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TargetValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    AchieveValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MeasuringUnit = table.Column<string>(maxLength: 50, nullable: true),
                    BaselineDate = table.Column<DateTime>(type: "date", nullable: true),
                    Date1 = table.Column<DateTime>(type: "date", nullable: true),
                    Date2 = table.Column<DateTime>(type: "date", nullable: true),
                    Frequency1 = table.Column<string>(maxLength: 50, nullable: true),
                    Frequency2 = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Participants = table.Column<string>(maxLength: 50, nullable: true),
                    PrimarySource = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame2ndStepOutput", x => x.LogFrame2ndStepOutputId);
                    table.ForeignKey(
                        name: "FK_LogFrame2ndStepOutput_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogFrame3rdStepActivity",
                columns: table => new
                {
                    LogFrame3rdStepActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    BaselineValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TargetValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    AchieveValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MeasuringUnit = table.Column<string>(maxLength: 50, nullable: true),
                    BaselineDate = table.Column<DateTime>(type: "date", nullable: true),
                    Date1 = table.Column<DateTime>(type: "date", nullable: true),
                    Date2 = table.Column<DateTime>(type: "date", nullable: true),
                    Frequency1 = table.Column<string>(maxLength: 50, nullable: true),
                    Frequency2 = table.Column<string>(maxLength: 50, nullable: true),
                    Frequency3 = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Participants = table.Column<string>(maxLength: 50, nullable: true),
                    PrimarySource = table.Column<string>(maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Expenditure = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    CurrencyMeasuringUnit = table.Column<string>(maxLength: 50, nullable: true),
                    SummaryOrRemarks = table.Column<string>(maxLength: 128, nullable: true),
                    ReasonOfDeviation = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame3rdStepActivity", x => x.LogFrame3rdStepActivityId);
                    table.ForeignKey(
                        name: "FK_LogFrame3rdStepActivity_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame2ndStepOutput_ProjectId",
                table: "LogFrame2ndStepOutput",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame3rdStepActivity_ProjectId",
                table: "LogFrame3rdStepActivity",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrame2ndStepOutput");

            migrationBuilder.DropTable(
                name: "LogFrame3rdStepActivity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date2",
                table: "LogFrame1stStepIndicator",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date1",
                table: "LogFrame1stStepIndicator",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaselineDate",
                table: "LogFrame1stStepIndicator",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
