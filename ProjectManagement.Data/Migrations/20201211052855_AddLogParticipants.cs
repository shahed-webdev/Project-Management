using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddLogParticipants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogFrame1stStepParticipant",
                columns: table => new
                {
                    LogFrame1stStepParticipantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectBeneficiaryTypeId = table.Column<int>(nullable: false),
                    LogFrame1stStepIndicatorId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame1stStepParticipant", x => x.LogFrame1stStepParticipantId);
                    table.ForeignKey(
                        name: "FK_LogFrame1stStepParticipant_LogFrame1stStepIndicator_LogFrame1stStepIndicatorId",
                        column: x => x.LogFrame1stStepIndicatorId,
                        principalTable: "LogFrame1stStepIndicator",
                        principalColumn: "LogFrame1stStepIndicatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrame1stStepParticipant_ProjectBeneficiaryType_ProjectBeneficiaryTypeId",
                        column: x => x.ProjectBeneficiaryTypeId,
                        principalTable: "ProjectBeneficiaryType",
                        principalColumn: "ProjectBeneficiaryTypeId");
                });

            migrationBuilder.CreateTable(
                name: "LogFrame2ndStepParticipant",
                columns: table => new
                {
                    LogFrame2ndStepParticipantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectBeneficiaryTypeId = table.Column<int>(nullable: false),
                    LogFrame2ndStepOutputId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame2ndStepParticipant", x => x.LogFrame2ndStepParticipantId);
                    table.ForeignKey(
                        name: "FK_LogFrame2ndStepParticipant_LogFrame2ndStepOutput_LogFrame2ndStepOutputId",
                        column: x => x.LogFrame2ndStepOutputId,
                        principalTable: "LogFrame2ndStepOutput",
                        principalColumn: "LogFrame2ndStepOutputId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrame2ndStepParticipant_ProjectBeneficiaryType_ProjectBeneficiaryTypeId",
                        column: x => x.ProjectBeneficiaryTypeId,
                        principalTable: "ProjectBeneficiaryType",
                        principalColumn: "ProjectBeneficiaryTypeId");
                });

            migrationBuilder.CreateTable(
                name: "LogFrame3rdStepParticipant",
                columns: table => new
                {
                    LogFrame3rdStepParticipantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectBeneficiaryTypeId = table.Column<int>(nullable: false),
                    LogFrame3rdStepActivityId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame3rdStepParticipant", x => x.LogFrame3rdStepParticipantId);
                    table.ForeignKey(
                        name: "FK_LogFrame3rdStepParticipant_LogFrame3rdStepActivity_LogFrame3rdStepActivityId",
                        column: x => x.LogFrame3rdStepActivityId,
                        principalTable: "LogFrame3rdStepActivity",
                        principalColumn: "LogFrame3rdStepActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogFrame3rdStepParticipant_ProjectBeneficiaryType_ProjectBeneficiaryTypeId",
                        column: x => x.ProjectBeneficiaryTypeId,
                        principalTable: "ProjectBeneficiaryType",
                        principalColumn: "ProjectBeneficiaryTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame1stStepParticipant_LogFrame1stStepIndicatorId",
                table: "LogFrame1stStepParticipant",
                column: "LogFrame1stStepIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame1stStepParticipant_ProjectBeneficiaryTypeId",
                table: "LogFrame1stStepParticipant",
                column: "ProjectBeneficiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame2ndStepParticipant_LogFrame2ndStepOutputId",
                table: "LogFrame2ndStepParticipant",
                column: "LogFrame2ndStepOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame2ndStepParticipant_ProjectBeneficiaryTypeId",
                table: "LogFrame2ndStepParticipant",
                column: "ProjectBeneficiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame3rdStepParticipant_LogFrame3rdStepActivityId",
                table: "LogFrame3rdStepParticipant",
                column: "LogFrame3rdStepActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame3rdStepParticipant_ProjectBeneficiaryTypeId",
                table: "LogFrame3rdStepParticipant",
                column: "ProjectBeneficiaryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrame1stStepParticipant");

            migrationBuilder.DropTable(
                name: "LogFrame2ndStepParticipant");

            migrationBuilder.DropTable(
                name: "LogFrame3rdStepParticipant");
        }
    }
}
