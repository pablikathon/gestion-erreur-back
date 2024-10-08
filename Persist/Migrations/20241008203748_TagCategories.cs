using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class TagCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ErrorStatus",
                keyColumn: "Id",
                keyValue: "2975ba97-b760-4309-a366-d833e49febc9");

            migrationBuilder.DeleteData(
                table: "ErrorStatus",
                keyColumn: "Id",
                keyValue: "8d64ad28-1879-4356-b88b-a20be0022639");

            migrationBuilder.DeleteData(
                table: "ErrorStatus",
                keyColumn: "Id",
                keyValue: "b957fe19-8732-4d57-b248-c0b1268f9e04");

            migrationBuilder.DeleteData(
                table: "SeverityLevel",
                keyColumn: "Id",
                keyValue: "12ae4ac9-59d7-4630-b361-514d3297258");

            migrationBuilder.DeleteData(
                table: "SeverityLevel",
                keyColumn: "Id",
                keyValue: "281df6fe-3402-4a4b-b579-db92786dd61e");

            migrationBuilder.DeleteData(
                table: "SeverityLevel",
                keyColumn: "Id",
                keyValue: "7993fd1f-bc10-494d-83cb-002c58873ff6");

            migrationBuilder.DeleteData(
                table: "SeverityLevel",
                keyColumn: "Id",
                keyValue: "bd546955-66ca-4202-8e79-e60c414ce82c");

            migrationBuilder.CreateTable(
                name: "TagCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TagEntities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TagCategoriesTag",
                columns: table => new
                {
                    TagEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TagCategoryEntityId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategoriesTag", x => new { x.TagEntityId, x.TagCategoryEntityId });
                    table.ForeignKey(
                        name: "FK_TagCategoriesTag_TagCategories_TagCategoryEntityId",
                        column: x => x.TagCategoryEntityId,
                        principalTable: "TagCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagCategoriesTag_TagEntities_TagEntityId",
                        column: x => x.TagEntityId,
                        principalTable: "TagEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TagCategories_Title",
                table: "TagCategories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagCategoriesTag_TagCategoryEntityId",
                table: "TagCategoriesTag",
                column: "TagCategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEntities_Title",
                table: "TagEntities",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagCategoriesTag");

            migrationBuilder.DropTable(
                name: "TagCategories");

            migrationBuilder.DropTable(
                name: "TagEntities");

            migrationBuilder.InsertData(
                table: "ErrorStatus",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { "2975ba97-b760-4309-a366-d833e49febc9", "En cours" },
                    { "8d64ad28-1879-4356-b88b-a20be0022639", "Résolue" },
                    { "b957fe19-8732-4d57-b248-c0b1268f9e04", "Non Résolue" }
                });

            migrationBuilder.InsertData(
                table: "SeverityLevel",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { "12ae4ac9-59d7-4630-b361-514d3297258", "Critique" },
                    { "281df6fe-3402-4a4b-b579-db92786dd61e", "Modéré" },
                    { "7993fd1f-bc10-494d-83cb-002c58873ff6", "Faible" },
                    { "bd546955-66ca-4202-8e79-e60c414ce82c", "Élevé" }
                });
        }
    }
}
