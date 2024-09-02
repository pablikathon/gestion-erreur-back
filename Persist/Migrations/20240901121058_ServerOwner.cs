using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class ServerOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cost",
                table: "CustomerHaveLicenceToApplications",
                newName: "Cost");

            migrationBuilder.AddColumn<string>(
                    name: "CustomerWhoOwnServerId",
                    table: "Server",
                    type: "varchar(255)",
                    nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Server_CustomerWhoOwnServerId",
                table: "Server",
                column: "CustomerWhoOwnServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Server_Customer_CustomerWhoOwnServerId",
                table: "Server",
                column: "CustomerWhoOwnServerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Server_Customer_CustomerWhoOwnServerId",
                table: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Server_CustomerWhoOwnServerId",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "CustomerWhoOwnServerId",
                table: "Server");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "CustomerHaveLicenceToApplications",
                newName: "cost");
        }
    }
}