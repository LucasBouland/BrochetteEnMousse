using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MousseModels.Migrations
{
    public partial class ForeignKeyRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_UserID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Scenarios_ScenarioID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_AspNetUsers_UserID",
                table: "Scenarios");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Scenarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScenarioID",
                table: "Maps",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Maps",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_UserID",
                table: "Characters",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Scenarios_ScenarioID",
                table: "Maps",
                column: "ScenarioID",
                principalTable: "Scenarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_AspNetUsers_UserID",
                table: "Scenarios",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_UserID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Scenarios_ScenarioID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_AspNetUsers_UserID",
                table: "Scenarios");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Scenarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ScenarioID",
                table: "Maps",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Maps",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_UserID",
                table: "Characters",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Scenarios_ScenarioID",
                table: "Maps",
                column: "ScenarioID",
                principalTable: "Scenarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_AspNetUsers_UserID",
                table: "Scenarios",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
