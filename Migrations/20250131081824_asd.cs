using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saplings_SaplingCategory_SaplingCategoryId",
                table: "saplings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ccf2f45-a9f2-4214-bc7c-31445eb811ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a2ac3d-5705-4cd7-ace8-0ee75873016e");

            migrationBuilder.AlterColumn<int>(
                name: "SaplingCategoryId",
                table: "saplings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "saplings",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6664c247-5a4b-454a-8b06-1cc23b018765", null, "User", "USER" },
                    { "ec933740-2898-44b3-87f1-066510109177", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_saplings_SaplingCategory_SaplingCategoryId",
                table: "saplings",
                column: "SaplingCategoryId",
                principalTable: "SaplingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saplings_SaplingCategory_SaplingCategoryId",
                table: "saplings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6664c247-5a4b-454a-8b06-1cc23b018765");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec933740-2898-44b3-87f1-066510109177");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "saplings");

            migrationBuilder.AlterColumn<int>(
                name: "SaplingCategoryId",
                table: "saplings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ccf2f45-a9f2-4214-bc7c-31445eb811ff", null, "User", "USER" },
                    { "f2a2ac3d-5705-4cd7-ace8-0ee75873016e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_saplings_SaplingCategory_SaplingCategoryId",
                table: "saplings",
                column: "SaplingCategoryId",
                principalTable: "SaplingCategory",
                principalColumn: "Id");
        }
    }
}
