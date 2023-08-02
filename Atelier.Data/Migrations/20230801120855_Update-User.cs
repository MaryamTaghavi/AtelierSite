using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelier.Data.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "TypeUser",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "DeletedDate", "EditedDate", "FullName", "Password", "PhoneNumber", "TypeUser", "UserName" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 21, 32, 968, DateTimeKind.Local).AddTicks(1379), null, null, "فاطمه جعفری", "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E", "09130023409", 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Title");
        }
    }
}
