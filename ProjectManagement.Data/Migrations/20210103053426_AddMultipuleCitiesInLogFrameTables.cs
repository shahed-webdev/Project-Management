using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddMultipuleCitiesInLogFrameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LogFrame1stStepCity",
                columns: table => new
                {
                    LogFrame1stStepCityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(nullable: false),
                    LogFrame1stStepIndicatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame1stStepCity", x => x.LogFrame1stStepCityId);
                    table.ForeignKey(
                        name: "FK_LogFrame1stStepCity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_LogFrame1stStepCity_LogFrame1stStepIndicator_LogFrame1stStepIndicatorId",
                        column: x => x.LogFrame1stStepIndicatorId,
                        principalTable: "LogFrame1stStepIndicator",
                        principalColumn: "LogFrame1stStepIndicatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogFrame2ndStepCity",
                columns: table => new
                {
                    LogFrame2ndStepCityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogFrame2ndStepOutputId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame2ndStepCity", x => x.LogFrame2ndStepCityId);
                    table.ForeignKey(
                        name: "FK_LogFrame2ndStepCity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_LogFrame2ndStepCity_LogFrame2ndStepOutput_LogFrame2ndStepOutputId",
                        column: x => x.LogFrame2ndStepOutputId,
                        principalTable: "LogFrame2ndStepOutput",
                        principalColumn: "LogFrame2ndStepOutputId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogFrame3rdStepCity",
                columns: table => new
                {
                    LogFrame3rdStepCityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogFrame3rdStepActivityId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame3rdStepCity", x => x.LogFrame3rdStepCityId);
                    table.ForeignKey(
                        name: "FK_LogFrame3rdStepCity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_LogFrame3rdStepCity_LogFrame3rdStepActivity_LogFrame3rdStepActivityId",
                        column: x => x.LogFrame3rdStepActivityId,
                        principalTable: "LogFrame3rdStepActivity",
                        principalColumn: "LogFrame3rdStepActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame1stStepCity_CityId",
                table: "LogFrame1stStepCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame1stStepCity_LogFrame1stStepIndicatorId",
                table: "LogFrame1stStepCity",
                column: "LogFrame1stStepIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame2ndStepCity_CityId",
                table: "LogFrame2ndStepCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame2ndStepCity_LogFrame2ndStepOutputId",
                table: "LogFrame2ndStepCity",
                column: "LogFrame2ndStepOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame3rdStepCity_CityId",
                table: "LogFrame3rdStepCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame3rdStepCity_LogFrame3rdStepActivityId",
                table: "LogFrame3rdStepCity",
                column: "LogFrame3rdStepActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrame1stStepCity");

            migrationBuilder.DropTable(
                name: "LogFrame2ndStepCity");

            migrationBuilder.DropTable(
                name: "LogFrame3rdStepCity");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LogFrame3rdStepActivity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LogFrame2ndStepOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LogFrame1stStepIndicator",
                type: "int",
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
    }
}
