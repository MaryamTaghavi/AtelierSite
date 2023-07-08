using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelier.Data.Migrations
{
    public partial class editCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtelierGroups_Ateliers_AtelierId",
                table: "AtelierGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AtelierGroups_Groupings_GroupId",
                table: "AtelierGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Cities_CityId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Users_UserId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "Tilte",
                table: "Cities");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierGroups_Ateliers_AtelierId",
                table: "AtelierGroups",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierGroups_Groupings_GroupId",
                table: "AtelierGroups",
                column: "GroupId",
                principalTable: "Groupings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Cities_CityId",
                table: "Ateliers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Users_UserId",
                table: "Ateliers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtelierGroups_Ateliers_AtelierId",
                table: "AtelierGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AtelierGroups_Groupings_GroupId",
                table: "AtelierGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Cities_CityId",
                table: "Ateliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ateliers_Users_UserId",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cities");

            migrationBuilder.AddColumn<string>(
                name: "Tilte",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierGroups_Ateliers_AtelierId",
                table: "AtelierGroups",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtelierGroups_Groupings_GroupId",
                table: "AtelierGroups",
                column: "GroupId",
                principalTable: "Groupings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Cities_CityId",
                table: "Ateliers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ateliers_Users_UserId",
                table: "Ateliers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
