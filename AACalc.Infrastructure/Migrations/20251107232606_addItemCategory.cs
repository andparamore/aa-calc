using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AACalc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addItemCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoolId",
                table: "synthesis_pools",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemCategory",
                table: "items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemSubtype",
                table: "items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoolId",
                table: "synthesis_pools");

            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "items");

            migrationBuilder.DropColumn(
                name: "ItemSubtype",
                table: "items");
        }
    }
}
