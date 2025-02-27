using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ebce4b4-8c2e-449b-9d5f-c48e8ce7afe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfad9709-2d86-4ec2-878d-ade7fe8afda6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2add8c6a-eae2-4291-991f-d7d747b995cd", null, "User", "USER" },
                    { "39ae86cb-35e1-4e84-916e-e0fc74c64fa5", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2add8c6a-eae2-4291-991f-d7d747b995cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39ae86cb-35e1-4e84-916e-e0fc74c64fa5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ebce4b4-8c2e-449b-9d5f-c48e8ce7afe4", null, "Admin", "ADMIN" },
                    { "dfad9709-2d86-4ec2-878d-ade7fe8afda6", null, "User", "USER" }
                });
        }
    }
}
