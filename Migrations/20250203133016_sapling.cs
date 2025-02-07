using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class sapling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242cedb5-8669-49f3-8ff2-bb1118bfe0d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e86ca9b-7ef4-4b91-a5ed-4155910cc042");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "saplings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09393e07-f727-4036-80eb-59b0f3f9b743", null, "Admin", "ADMIN" },
                    { "43945d0b-ebfa-432c-9c46-58fdff3abf80", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09393e07-f727-4036-80eb-59b0f3f9b743");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43945d0b-ebfa-432c-9c46-58fdff3abf80");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "saplings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "242cedb5-8669-49f3-8ff2-bb1118bfe0d8", null, "User", "USER" },
                    { "9e86ca9b-7ef4-4b91-a5ed-4155910cc042", null, "Admin", "ADMIN" }
                });
        }
    }
}
