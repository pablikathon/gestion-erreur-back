using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persist.Migrations
{
    /// <inheritdoc />
    public partial class interventionDateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Error",
                newName: "InterventionDate");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "InterventionDate",
                table: "Error",
                newName: "EventDate");
        }
    }
}
