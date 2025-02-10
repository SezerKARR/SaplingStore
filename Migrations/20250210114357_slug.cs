using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class slug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c3a703-fe5e-45bc-9b52-770fb29d0852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8d82e86-c9c8-4aa3-a999-839ab1b0cfa5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42098a55-8492-44de-ba7c-44fcf7518629", null, "User", "USER" },
                    { "c2ecf85a-d5ce-4fad-b067-7516038cf0c5", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42098a55-8492-44de-ba7c-44fcf7518629");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2ecf85a-d5ce-4fad-b067-7516038cf0c5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c3a703-fe5e-45bc-9b52-770fb29d0852", null, "User", "USER" },
                    { "c8d82e86-c9c8-4aa3-a999-839ab1b0cfa5", null, "Admin", "ADMIN" }
                });
        }
    }
}
