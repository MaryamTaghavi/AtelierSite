using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelier.Data.Migrations
{
    public partial class updateColumnGrouping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tilte",
                table: "Groupings");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Groupings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Groupings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "Groupings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Groupings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Groupings");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Groupings");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Groupings");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Groupings");

            migrationBuilder.AddColumn<string>(
                name: "Tilte",
                table: "Groupings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
