using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "SaplingCategory");

            migrationBuilder.RenameTable(
                name: "SaplingHeights",
                newName: "saplingHeights");

            migrationBuilder.RenameIndex(
                name: "IX_SaplingHeights_SaplingId",
                table: "saplingHeights",
                newName: "IX_saplingHeights_SaplingId");

            migrationBuilder.UpdateData(
                table: "saplings",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "saplings",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "saplings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "saplingHeights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "saplingHeights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SaplingCategory",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SaplingCategory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "SaplingCategory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saplingHeights",
                table: "saplingHeights",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c3a703-fe5e-45bc-9b52-770fb29d0852", null, "User", "USER" },
                    { "c8d82e86-c9c8-4aa3-a999-839ab1b0cfa5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_saplingHeights_saplings_SaplingId",
                table: "saplingHeights",
                column: "SaplingId",
                principalTable: "saplings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saplingHeights_saplings_SaplingId",
                table: "saplingHeights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saplingHeights",
                table: "saplingHeights");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c3a703-fe5e-45bc-9b52-770fb29d0852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8d82e86-c9c8-4aa3-a999-839ab1b0cfa5");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "saplings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "saplingHeights");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "saplingHeights");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SaplingCategory");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "SaplingCategory");

            migrationBuilder.RenameTable(
                name: "saplingHeights",
                newName: "SaplingHeights");

            migrationBuilder.RenameIndex(
                name: "IX_saplingHeights_SaplingId",
                table: "SaplingHeights",
                newName: "IX_SaplingHeights_SaplingId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "saplings",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "SaplingCategory",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "SaplingCategory",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
