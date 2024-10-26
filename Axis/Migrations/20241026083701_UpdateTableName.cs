using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CS_EXP_Project_Translation",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProjectManager = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Analyst = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BenchmarkFileId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GoLiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditMSID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    NDBLOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NewMarket = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RefreshInd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_Project_Translation", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    CompetitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Reference to the parent project"),
                    PayorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the payor"),
                    Product = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Product name"),
                    CSPIndicator = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "CSP indicator flag"),
                    EIIndicator = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "EI indicator flag"),
                    MRIndicator = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "MR indicator flag"),
                    SPCIndicator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "SPC indicator value")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.CompetitorId);
                    table.ForeignKey(
                        name: "FK_Competitors_CS_EXP_Project_Translation_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "CS_EXP_Project_Translation",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Reference to the parent project"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Note category"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Note content"),
                    LoadDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Date when the note was created"),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Date when the note was last edited"),
                    OriginalMSID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "MSID of the user who created the note"),
                    LastEditMSID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "MSID of the last user to edit the note")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_ProjectNotes_CS_EXP_Project_Translation_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "CS_EXP_Project_Translation",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YLines",
                columns: table => new
                {
                    YLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Reference to the parent project"),
                    IPANumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "IPA number"),
                    MarketNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Market number"),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Product code"),
                    IsPreAward = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates if this is a pre-award Y-Line"),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates if this is an optional Y-Line")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YLines", x => x.YLineId);
                    table.ForeignKey(
                        name: "FK_YLines_CS_EXP_Project_Translation_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "CS_EXP_Project_Translation",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_ProjectId",
                table: "Competitors",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_ProjectId_PayorName_Product",
                table: "Competitors",
                columns: new[] { "ProjectId", "PayorName", "Product" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotes_Category",
                table: "ProjectNotes",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotes_LoadDate",
                table: "ProjectNotes",
                column: "LoadDate");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotes_ProjectId",
                table: "ProjectNotes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_YLines_ProjectId",
                table: "YLines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_YLines_ProjectId_IPANumber",
                table: "YLines",
                columns: new[] { "ProjectId", "IPANumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "ProjectNotes");

            migrationBuilder.DropTable(
                name: "YLines");

            migrationBuilder.DropTable(
                name: "CS_EXP_Project_Translation");
        }
    }
}
