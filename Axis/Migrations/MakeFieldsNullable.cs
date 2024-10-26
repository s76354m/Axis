using Microsoft.EntityFrameworkCore.Migrations;

namespace Axis.Migrations
{
    public partial class MakeFieldsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Project Table
            migrationBuilder.AlterColumn<string>(
                name: "ProjectType",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectManager",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectDescription",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewMarket",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NDBLOB",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastEditMSID",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BenchmarkFileId",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Analyst",
                table: "CS_EXP_Project_Translation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            // Competitors Table
            migrationBuilder.AlterColumn<string>(
                name: "SPCIndicator",
                table: "Competitors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Product",
                table: "Competitors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PayorName",
                table: "Competitors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            // YLines Table
            migrationBuilder.AlterColumn<string>(
                name: "IPANumber",
                table: "YLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            // Drop the unique constraint before modifying columns
            migrationBuilder.DropIndex(
                name: "IX_YLines_ProjectId_IPANumber",
                table: "YLines");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_ProjectId_PayorName_Product",
                table: "Competitors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Implement the reverse changes if needed to roll back
            // Note: This is a destructive change if data contains nulls
        }
    }
}
