using Microsoft.EntityFrameworkCore.Migrations;

namespace MousseModels.Migrations
{
    public partial class ManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignUser",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CampaignID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    IsGameMaster = table.Column<bool>(nullable: false),
                    CharacterID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CampaignUser_Campaigns_CampaignID",
                        column: x => x.CampaignID,
                        principalTable: "Campaigns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignUser_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignUser_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCampaign",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CharacterID = table.Column<string>(nullable: true),
                    CampaignID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCampaign", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterCampaign_Campaigns_CampaignID",
                        column: x => x.CampaignID,
                        principalTable: "Campaigns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterCampaign_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioMonster",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ScenarioID = table.Column<string>(nullable: true),
                    MonsterID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioMonster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScenarioMonster_Monsters_MonsterID",
                        column: x => x.MonsterID,
                        principalTable: "Monsters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScenarioMonster_Scenarios_ScenarioID",
                        column: x => x.ScenarioID,
                        principalTable: "Scenarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioSession",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ScenarioID = table.Column<string>(nullable: true),
                    SessionID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioSession", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScenarioSession_Scenarios_ScenarioID",
                        column: x => x.ScenarioID,
                        principalTable: "Scenarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScenarioSession_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionUser",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    SessionID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SessionUser_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionUser_AspNetUsers_SessionID",
                        column: x => x.SessionID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUser_CampaignID",
                table: "CampaignUser",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUser_CharacterID",
                table: "CampaignUser",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUser_UserID",
                table: "CampaignUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCampaign_CampaignID",
                table: "CharacterCampaign",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCampaign_CharacterID",
                table: "CharacterCampaign",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioMonster_MonsterID",
                table: "ScenarioMonster",
                column: "MonsterID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioMonster_ScenarioID",
                table: "ScenarioMonster",
                column: "ScenarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioSession_ScenarioID",
                table: "ScenarioSession",
                column: "ScenarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioSession_SessionID",
                table: "ScenarioSession",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionUser_SessionID",
                table: "SessionUser",
                column: "SessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignUser");

            migrationBuilder.DropTable(
                name: "CharacterCampaign");

            migrationBuilder.DropTable(
                name: "ScenarioMonster");

            migrationBuilder.DropTable(
                name: "ScenarioSession");

            migrationBuilder.DropTable(
                name: "SessionUser");
        }
    }
}
