using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddCompetitorColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "YLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadDate",
                table: "YLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Lives",
                table: "Competitors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadDate",
                table: "Competitors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MarketShare",
                table: "Competitors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "YLines");

            migrationBuilder.DropColumn(
                name: "LoadDate",
                table: "YLines");

            migrationBuilder.DropColumn(
                name: "Lives",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "LoadDate",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "MarketShare",
                table: "Competitors");
        }
    }
}
