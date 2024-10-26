using Microsoft.EntityFrameworkCore.Migrations;

namespace Axis.Migrations
{
    public partial class AddCompetitorColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lives",
                table: "Competitors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketShare",
                table: "Competitors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadDate",
                table: "Competitors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lives",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "MarketShare",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "LoadDate",
                table: "Competitors");
        }
    }
}
