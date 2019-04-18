using Microsoft.EntityFrameworkCore.Migrations;

namespace MousseModels.Migrations
{
    public partial class ContentScenario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Scenarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Scenarios");
        }
    }
}
