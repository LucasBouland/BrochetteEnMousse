using Microsoft.EntityFrameworkCore.Migrations;

namespace MousseModels.Migrations
{
    public partial class FixSessionAndCampaignLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_CampaignID",
                table: "Sessions");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Campaigns_CampaignID",
                table: "Sessions",
                column: "CampaignID",
                principalTable: "Campaigns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Campaigns_CampaignID",
                table: "Sessions");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_CampaignID",
                table: "Sessions",
                column: "CampaignID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
