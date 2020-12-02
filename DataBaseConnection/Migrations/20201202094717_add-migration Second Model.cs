using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseConnection.Migrations
{
    public partial class addmigrationSecondModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Email", "Firstname", "Lastname" },
                values: new object[] { 1, 12, "AlanWeik@gmail.com", "Alan", "Weik" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ImageURL", "Title" },
                values: new object[] { 1, "Fantasy", "", "Lord of the rings " });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Date", "MovieId" },
                values: new object[] { 1, null, new DateTime(2020, 12, 2, 10, 47, 16, 583, DateTimeKind.Local).AddTicks(4844), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Customers",
                newName: "Name");
        }
    }
}
