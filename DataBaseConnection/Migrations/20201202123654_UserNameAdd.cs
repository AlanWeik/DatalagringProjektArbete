using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseConnection.Migrations
{
    public partial class UserNameAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 2, 13, 36, 53, 757, DateTimeKind.Local).AddTicks(6308));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 2, 10, 47, 16, 583, DateTimeKind.Local).AddTicks(4844));
        }
    }
}
