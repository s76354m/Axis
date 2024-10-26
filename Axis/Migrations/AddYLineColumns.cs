using Microsoft.EntityFrameworkCore.Migrations;

namespace Axis.Migrations
{
    public partial class AddYLineColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LoadDate",
                table: "YLines",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "YLines",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoadDate",
                table: "YLines");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "YLines");
        }
    }
}
