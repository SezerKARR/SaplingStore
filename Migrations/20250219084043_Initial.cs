using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "936a14cf-4ec4-4af9-9ee0-2d0def77b7a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9ac2395-1d3b-4d61-a22b-6f86a30b4bd2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81386ed7-8ae4-467e-9b43-af1925f0e623", null, "User", "USER" },
                    { "f8c21515-145f-45b6-a7c0-d31eef1679e4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81386ed7-8ae4-467e-9b43-af1925f0e623");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c21515-145f-45b6-a7c0-d31eef1679e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "936a14cf-4ec4-4af9-9ee0-2d0def77b7a6", null, "User", "USER" },
                    { "d9ac2395-1d3b-4d61-a22b-6f86a30b4bd2", null, "Admin", "ADMIN" }
                });
        }
    }
}
