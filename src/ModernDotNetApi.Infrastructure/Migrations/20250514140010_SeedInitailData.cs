using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModernDotNetApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitailData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApiEntries",
                columns: new[] { "Id", "Category", "Description", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "open source", "openai api - 1", "openai -1", "http://openai.org/1" },
                    { 2, "open source", "openai api - 2", "openai -2", "http://openai.org/2" },
                    { 3, "open source", "openai api - 3", "openai -3", "http://openai.org/3" },
                    { 4, "open source", "openai api - 4", "openai -4", "http://openai.org/4" },
                    { 5, "open source", "openai api - 5", "openai -5", "http://openai.org/5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApiEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApiEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApiEntries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApiEntries",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
