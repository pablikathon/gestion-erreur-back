using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCategoriesTag_TagEntities_TagEntityId",
                table: "TagCategoriesTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagEntities",
                table: "TagEntities");

            migrationBuilder.RenameTable(
                name: "TagEntities",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_TagEntities_Title",
                table: "Tag",
                newName: "IX_Tag_Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPrenium = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EverybodyCouldUseIt = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ApplicationEntityId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature_Application_ApplicationEntityId",
                        column: x => x.ApplicationEntityId,
                        principalTable: "Application",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerEntityFeatureEntity",
                columns: table => new
                {
                    CustomerHaveAccessToAFeatureId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomersWhoCanUseFeatureId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEntityFeatureEntity", x => new { x.CustomerHaveAccessToAFeatureId, x.CustomersWhoCanUseFeatureId });
                    table.ForeignKey(
                        name: "FK_CustomerEntityFeatureEntity_Customer_CustomersWhoCanUseFeatu~",
                        column: x => x.CustomersWhoCanUseFeatureId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEntityFeatureEntity_Feature_CustomerHaveAccessToAFea~",
                        column: x => x.CustomerHaveAccessToAFeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotObligatory = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FeatureId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreviousStepId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Step_Step_PreviousStepId",
                        column: x => x.PreviousStepId,
                        principalTable: "Step",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEntityFeatureEntity_CustomersWhoCanUseFeatureId",
                table: "CustomerEntityFeatureEntity",
                column: "CustomersWhoCanUseFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_ApplicationEntityId",
                table: "Feature",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_FeatureId",
                table: "Step",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_PreviousStepId",
                table: "Step",
                column: "PreviousStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Title",
                table: "Step",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCategoriesTag_Tag_TagEntityId",
                table: "TagCategoriesTag",
                column: "TagEntityId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCategoriesTag_Tag_TagEntityId",
                table: "TagCategoriesTag");

            migrationBuilder.DropTable(
                name: "CustomerEntityFeatureEntity");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "TagEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_Title",
                table: "TagEntities",
                newName: "IX_TagEntities_Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagEntities",
                table: "TagEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCategoriesTag_TagEntities_TagEntityId",
                table: "TagCategoriesTag",
                column: "TagEntityId",
                principalTable: "TagEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
