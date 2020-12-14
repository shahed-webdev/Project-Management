using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddCityInLogFrame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LogFrame3rdStepActivity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LogFrame2ndStepOutput",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LogFrame1stStepIndicator",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame3rdStepActivity_CityId",
                table: "LogFrame3rdStepActivity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame2ndStepOutput_CityId",
                table: "LogFrame2ndStepOutput",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame1stStepIndicator_CityId",
                table: "LogFrame1stStepIndicator",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrame1stStepIndicator_City_CityId",
                table: "LogFrame1stStepIndicator",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrame2ndStepOutput_City_CityId",
                table: "LogFrame2ndStepOutput",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogFrame3rdStepActivity_City_CityId",
                table: "LogFrame3rdStepActivity",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogFrame1stStepIndicator_City_CityId",
                table: "LogFrame1stStepIndicator");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrame2ndStepOutput_City_CityId",
                table: "LogFrame2ndStepOutput");

            migrationBuilder.DropForeignKey(
                name: "FK_LogFrame3rdStepActivity_City_CityId",
                table: "LogFrame3rdStepActivity");

            migrationBuilder.DropIndex(
                name: "IX_LogFrame3rdStepActivity_CityId",
                table: "LogFrame3rdStepActivity");

            migrationBuilder.DropIndex(
                name: "IX_LogFrame2ndStepOutput_CityId",
                table: "LogFrame2ndStepOutput");

            migrationBuilder.DropIndex(
                name: "IX_LogFrame1stStepIndicator_CityId",
                table: "LogFrame1stStepIndicator");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LogFrame3rdStepActivity");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LogFrame2ndStepOutput");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LogFrame1stStepIndicator");
        }
    }
}
