using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class applicationdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deployedApplicationEntities_Application_ApplicationId",
                table: "deployedApplicationEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_deployedApplicationEntities_Customer_CustomerId",
                table: "deployedApplicationEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_deployedApplicationEntities_Server_ServerId",
                table: "deployedApplicationEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deployedApplicationEntities",
                table: "deployedApplicationEntities");

            migrationBuilder.RenameTable(
                name: "deployedApplicationEntities",
                newName: "DeployedApplication");

            migrationBuilder.RenameIndex(
                name: "IX_deployedApplicationEntities_CustomerId",
                table: "DeployedApplication",
                newName: "IX_DeployedApplication_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_deployedApplicationEntities_ApplicationId",
                table: "DeployedApplication",
                newName: "IX_DeployedApplication_ApplicationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Application",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeployedApplication",
                table: "DeployedApplication",
                columns: new[] { "ServerId", "ApplicationId", "CustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeployedApplication_Application_ApplicationId",
                table: "DeployedApplication",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeployedApplication_Customer_CustomerId",
                table: "DeployedApplication",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeployedApplication_Server_ServerId",
                table: "DeployedApplication",
                column: "ServerId",
                principalTable: "Server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeployedApplication_Application_ApplicationId",
                table: "DeployedApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_DeployedApplication_Customer_CustomerId",
                table: "DeployedApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_DeployedApplication_Server_ServerId",
                table: "DeployedApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeployedApplication",
                table: "DeployedApplication");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "DeployedApplication",
                newName: "deployedApplicationEntities");

            migrationBuilder.RenameIndex(
                name: "IX_DeployedApplication_CustomerId",
                table: "deployedApplicationEntities",
                newName: "IX_deployedApplicationEntities_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_DeployedApplication_ApplicationId",
                table: "deployedApplicationEntities",
                newName: "IX_deployedApplicationEntities_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deployedApplicationEntities",
                table: "deployedApplicationEntities",
                columns: new[] { "ServerId", "ApplicationId", "CustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_deployedApplicationEntities_Application_ApplicationId",
                table: "deployedApplicationEntities",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deployedApplicationEntities_Customer_CustomerId",
                table: "deployedApplicationEntities",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deployedApplicationEntities_Server_ServerId",
                table: "deployedApplicationEntities",
                column: "ServerId",
                principalTable: "Server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
