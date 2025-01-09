using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class Createdroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86adc721-a9d7-4b30-8781-e54217518d9f", "86adc721-a9d7-4b30-8781-e54217518d9f", null, "READER" },
                    { "cd529d3a-f299-46ec-b6f4-0caa98059a8d", "cd529d3a-f299-46ec-b6f4-0caa98059a8d", null, "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86adc721-a9d7-4b30-8781-e54217518d9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd529d3a-f299-46ec-b6f4-0caa98059a8d");
        }
    }
}
