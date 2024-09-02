using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class addColumnAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeployedApplication");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Server",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HasToMakeSupportSince",
                table: "Server",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HostedSince",
                table: "Server",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Server",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StopHost",
                table: "Server",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstInteraction",
                table: "Customer",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customer",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Internal",
                table: "Application",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                    name: "ApplicationDeployedOnServer",
                    columns: table => new
                    {
                        ServerId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        ApplicationId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        CustomerId = table.Column<string>(type: "varchar(255)", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        ApplicationPath = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_ApplicationDeployedOnServer", x => new { x.ServerId, x.ApplicationId });
                        table.ForeignKey(
                            name: "FK_ApplicationDeployedOnServer_Application_ApplicationId",
                            column: x => x.ApplicationId,
                            principalTable: "Application",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_ApplicationDeployedOnServer_Customer_CustomerId",
                            column: x => x.CustomerId,
                            principalTable: "Customer",
                            principalColumn: "Id");
                        table.ForeignKey(
                            name: "FK_ApplicationDeployedOnServer_Server_ServerId",
                            column: x => x.ServerId,
                            principalTable: "Server",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                    name: "CustomerHaveLicenceToApplications",
                    columns: table => new
                    {
                        ApplicationId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        CustomerId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        BeginingSupport = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                        EndingSupport = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                        cost = table.Column<double>(type: "double", nullable: false),
                        IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_CustomerHaveLicenceToApplications",
                            x => new { x.CustomerId, x.ApplicationId });
                        table.ForeignKey(
                            name: "FK_CustomerHaveLicenceToApplications_Application_ApplicationId",
                            column: x => x.ApplicationId,
                            principalTable: "Application",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_CustomerHaveLicenceToApplications_Customer_CustomerId",
                            column: x => x.CustomerId,
                            principalTable: "Customer",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDeployedOnServer_ApplicationId",
                table: "ApplicationDeployedOnServer",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDeployedOnServer_CustomerId",
                table: "ApplicationDeployedOnServer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHaveLicenceToApplications_ApplicationId",
                table: "CustomerHaveLicenceToApplications",
                column: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationDeployedOnServer");

            migrationBuilder.DropTable(
                name: "CustomerHaveLicenceToApplications");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "HasToMakeSupportSince",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "HostedSince",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "StopHost",
                table: "Server");

            migrationBuilder.DropColumn(
                name: "FirstInteraction",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Internal",
                table: "Application");

            migrationBuilder.CreateTable(
                    name: "DeployedApplication",
                    columns: table => new
                    {
                        ServerId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        ApplicationId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        CustomerId = table.Column<string>(type: "varchar(255)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4")
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_DeployedApplication",
                            x => new { x.ServerId, x.ApplicationId, x.CustomerId });
                        table.ForeignKey(
                            name: "FK_DeployedApplication_Application_ApplicationId",
                            column: x => x.ApplicationId,
                            principalTable: "Application",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_DeployedApplication_Customer_CustomerId",
                            column: x => x.CustomerId,
                            principalTable: "Customer",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_DeployedApplication_Server_ServerId",
                            column: x => x.ServerId,
                            principalTable: "Server",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DeployedApplication_ApplicationId",
                table: "DeployedApplication",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeployedApplication_CustomerId",
                table: "DeployedApplication",
                column: "CustomerId");
        }
    }
}