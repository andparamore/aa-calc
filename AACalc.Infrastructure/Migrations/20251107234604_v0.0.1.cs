using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AACalc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_items_ItemType_ItemGroup",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_qualities_ItemId_QualityType",
                table: "qualities",
                columns: new[] { "ItemId", "QualityType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemCategory_ItemType",
                table: "items",
                columns: new[] { "ItemCategory", "ItemType" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_qualities_ItemId_QualityType",
                table: "qualities");

            migrationBuilder.DropIndex(
                name: "IX_items_ItemCategory_ItemType",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemType_ItemGroup",
                table: "items",
                columns: new[] { "ItemType", "ItemGroup" },
                unique: true);
        }
    }
}
