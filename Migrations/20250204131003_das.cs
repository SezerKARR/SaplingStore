using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class das : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaplingHeight_saplings_SaplingId",
                table: "SaplingHeight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaplingHeight",
                table: "SaplingHeight");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09393e07-f727-4036-80eb-59b0f3f9b743");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43945d0b-ebfa-432c-9c46-58fdff3abf80");

            migrationBuilder.RenameTable(
                name: "SaplingHeight",
                newName: "SaplingHeights");

            migrationBuilder.RenameIndex(
                name: "IX_SaplingHeight_SaplingId",
                table: "SaplingHeights",
                newName: "IX_SaplingHeights_SaplingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaplingHeights",
                table: "SaplingHeights",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d597db-15b4-4ba2-8626-1d5de573feef", null, "Admin", "ADMIN" },
                    { "c5d4ca25-a021-439b-9945-ed6db7d30cf8", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SaplingHeights_saplings_SaplingId",
                table: "SaplingHeights",
                column: "SaplingId",
                principalTable: "saplings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaplingHeights_saplings_SaplingId",
                table: "SaplingHeights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaplingHeights",
                table: "SaplingHeights");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d597db-15b4-4ba2-8626-1d5de573feef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5d4ca25-a021-439b-9945-ed6db7d30cf8");

            migrationBuilder.RenameTable(
                name: "SaplingHeights",
                newName: "SaplingHeight");

            migrationBuilder.RenameIndex(
                name: "IX_SaplingHeights_SaplingId",
                table: "SaplingHeight",
                newName: "IX_SaplingHeight_SaplingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaplingHeight",
                table: "SaplingHeight",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09393e07-f727-4036-80eb-59b0f3f9b743", null, "Admin", "ADMIN" },
                    { "43945d0b-ebfa-432c-9c46-58fdff3abf80", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SaplingHeight_saplings_SaplingId",
                table: "SaplingHeight",
                column: "SaplingId",
                principalTable: "saplings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
