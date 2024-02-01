using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class removeuselesskeyinitemEntrySpotter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntrySpotter_Entries_EntryId",
                table: "EntrySpotter");

            migrationBuilder.DropForeignKey(
                name: "FK_EntrySpotter_Spotter_SpotterId",
                table: "EntrySpotter");

            migrationBuilder.DropIndex(
                name: "IX_EntrySpotter_EntryId",
                table: "EntrySpotter");

            migrationBuilder.DropIndex(
                name: "IX_EntrySpotter_SpotterId",
                table: "EntrySpotter");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "EntrySpotter");

            migrationBuilder.DropColumn(
                name: "SpotterId",
                table: "EntrySpotter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntryId",
                table: "EntrySpotter",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SpotterId",
                table: "EntrySpotter",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EntrySpotter_EntryId",
                table: "EntrySpotter",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrySpotter_SpotterId",
                table: "EntrySpotter",
                column: "SpotterId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntrySpotter_Entries_EntryId",
                table: "EntrySpotter",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntrySpotter_Spotter_SpotterId",
                table: "EntrySpotter",
                column: "SpotterId",
                principalTable: "Spotter",
                principalColumn: "Id");
        }
    }
}
