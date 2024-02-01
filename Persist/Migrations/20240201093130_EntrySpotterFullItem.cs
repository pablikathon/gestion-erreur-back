using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class EntrySpotterFullItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdSpotter",
                table: "EntrySpotter",
                newName: "SpotterId");

            migrationBuilder.RenameColumn(
                name: "IdEntry",
                table: "EntrySpotter",
                newName: "EntryId");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntrySpotter_Entries_EntryId",
                table: "EntrySpotter");

            migrationBuilder.DropForeignKey(
                name: "FK_EntrySpotter_Spotter_SpotterId",
                table: "EntrySpotter");

            migrationBuilder.DropIndex(
                name: "IX_EntrySpotter_SpotterId",
                table: "EntrySpotter");

            migrationBuilder.RenameColumn(
                name: "SpotterId",
                table: "EntrySpotter",
                newName: "IdSpotter");

            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "EntrySpotter",
                newName: "IdEntry");
        }
    }
}
