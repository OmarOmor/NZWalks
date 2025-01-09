using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class Assignedvaluetonamefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86adc721-a9d7-4b30-8781-e54217518d9f",
                column: "Name",
                value: "Reader");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd529d3a-f299-46ec-b6f4-0caa98059a8d",
                column: "Name",
                value: "Writer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86adc721-a9d7-4b30-8781-e54217518d9f",
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd529d3a-f299-46ec-b6f4-0caa98059a8d",
                column: "Name",
                value: null);
        }
    }
}
