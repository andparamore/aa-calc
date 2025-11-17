using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AACalc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_items_ItemCategory_ItemType",
                table: "items");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "qualities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemCategory_ItemType_ItemGroup",
                table: "items",
                columns: new[] { "ItemCategory", "ItemType", "ItemGroup" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_items_ItemCategory_ItemType_ItemGroup",
                table: "items");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "qualities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemCategory_ItemType",
                table: "items",
                columns: new[] { "ItemCategory", "ItemType" });
        }
    }
}
