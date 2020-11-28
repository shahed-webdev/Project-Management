using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddLogFrameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogFrame",
                columns: table => new
                {
                    LogFrameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectGoal = table.Column<string>(maxLength: 255, nullable: true),
                    ResultBaseIndicator = table.Column<string>(maxLength: 255, nullable: true),
                    Outcome = table.Column<string>(maxLength: 255, nullable: true),
                    OutcomeBaseIndicator = table.Column<string>(maxLength: 255, nullable: true),
                    Output = table.Column<string>(maxLength: 255, nullable: true),
                    OutputBaseIndicator = table.Column<string>(maxLength: 255, nullable: true),
                    Activity = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrame", x => x.LogFrameId);
                    table.ForeignKey(
                        name: "FK_LogFrame_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogFrame_ProjectId",
                table: "LogFrame",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFrame");
        }
    }
}
