using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class DeleteParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participants",
                table: "LogFrame3rdStepActivity");

            migrationBuilder.DropColumn(
                name: "Participants",
                table: "LogFrame2ndStepOutput");

            migrationBuilder.DropColumn(
                name: "Participants",
                table: "LogFrame1stStepIndicator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Participants",
                table: "LogFrame3rdStepActivity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Participants",
                table: "LogFrame2ndStepOutput",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Participants",
                table: "LogFrame1stStepIndicator",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
