using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelier.Data.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographer_Ateliers_AtelierId",
                table: "Photographer");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSample_Ateliers_AtelierId",
                table: "WorkSample");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSample_Groupings_GroupId",
                table: "WorkSample");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSample",
                table: "WorkSample");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photographer",
                table: "Photographer");

            migrationBuilder.RenameTable(
                name: "WorkSample",
                newName: "WorkSamples");

            migrationBuilder.RenameTable(
                name: "Photographer",
                newName: "Photographers");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSample_GroupId",
                table: "WorkSamples",
                newName: "IX_WorkSamples_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSample_AtelierId",
                table: "WorkSamples",
                newName: "IX_WorkSamples_AtelierId");

            migrationBuilder.RenameIndex(
                name: "IX_Photographer_AtelierId",
                table: "Photographers",
                newName: "IX_Photographers_AtelierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSamples",
                table: "WorkSamples",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photographers",
                table: "Photographers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AtelierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Ateliers_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "Ateliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AtelierId",
                table: "Favorites",
                column: "AtelierId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographers_Ateliers_AtelierId",
                table: "Photographers",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSamples_Ateliers_AtelierId",
                table: "WorkSamples",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSamples_Groupings_GroupId",
                table: "WorkSamples",
                column: "GroupId",
                principalTable: "Groupings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographers_Ateliers_AtelierId",
                table: "Photographers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSamples_Ateliers_AtelierId",
                table: "WorkSamples");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSamples_Groupings_GroupId",
                table: "WorkSamples");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSamples",
                table: "WorkSamples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photographers",
                table: "Photographers");

            migrationBuilder.RenameTable(
                name: "WorkSamples",
                newName: "WorkSample");

            migrationBuilder.RenameTable(
                name: "Photographers",
                newName: "Photographer");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSamples_GroupId",
                table: "WorkSample",
                newName: "IX_WorkSample_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSamples_AtelierId",
                table: "WorkSample",
                newName: "IX_WorkSample_AtelierId");

            migrationBuilder.RenameIndex(
                name: "IX_Photographers_AtelierId",
                table: "Photographer",
                newName: "IX_Photographer_AtelierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSample",
                table: "WorkSample",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photographer",
                table: "Photographer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographer_Ateliers_AtelierId",
                table: "Photographer",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSample_Ateliers_AtelierId",
                table: "WorkSample",
                column: "AtelierId",
                principalTable: "Ateliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSample_Groupings_GroupId",
                table: "WorkSample",
                column: "GroupId",
                principalTable: "Groupings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
