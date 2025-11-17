using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AACalc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemGroup = table.Column<byte>(type: "smallint", nullable: false),
                    ItemType = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Icon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qualities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    QualityType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qualities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qualities_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attributes_key_value",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<short>(type: "smallint", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributes_key_value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attributes_key_value_qualities_QualityId",
                        column: x => x.QualityId,
                        principalTable: "qualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "synthesis_pools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<short>(type: "smallint", nullable: false),
                    MinValue = table.Column<int>(type: "integer", nullable: false),
                    MaxValue = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_synthesis_pools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_synthesis_pools_qualities_QualityId",
                        column: x => x.QualityId,
                        principalTable: "qualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attributes_key_value_QualityId",
                table: "attributes_key_value",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_key_value_QualityId_Key",
                table: "attributes_key_value",
                columns: new[] { "QualityId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemType_ItemGroup",
                table: "items",
                columns: new[] { "ItemType", "ItemGroup" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_qualities_ItemId",
                table: "qualities",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_synthesis_pools_QualityId",
                table: "synthesis_pools",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_synthesis_pools_QualityId_Key",
                table: "synthesis_pools",
                columns: new[] { "QualityId", "Key" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attributes_key_value");

            migrationBuilder.DropTable(
                name: "synthesis_pools");

            migrationBuilder.DropTable(
                name: "qualities");

            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
