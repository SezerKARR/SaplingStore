using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaplingStore.Migrations
{
    /// <inheritdoc />
    public partial class Heights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6664c247-5a4b-454a-8b06-1cc23b018765");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec933740-2898-44b3-87f1-066510109177");

            migrationBuilder.DropColumn(
                name: "Heights",
                table: "saplings");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SaplingCategory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SaplingHeight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SaplingId = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<float>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SaplingMoney = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaplingHeight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaplingHeight_saplings_SaplingId",
                        column: x => x.SaplingId,
                        principalTable: "saplings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "242cedb5-8669-49f3-8ff2-bb1118bfe0d8", null, "User", "USER" },
                    { "9e86ca9b-7ef4-4b91-a5ed-4155910cc042", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaplingHeight_SaplingId",
                table: "SaplingHeight",
                column: "SaplingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaplingHeight");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242cedb5-8669-49f3-8ff2-bb1118bfe0d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e86ca9b-7ef4-4b91-a5ed-4155910cc042");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SaplingCategory");

            migrationBuilder.AddColumn<string>(
                name: "Heights",
                table: "saplings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6664c247-5a4b-454a-8b06-1cc23b018765", null, "User", "USER" },
                    { "ec933740-2898-44b3-87f1-066510109177", null, "Admin", "ADMIN" }
                });
        }
    }
}
