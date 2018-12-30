using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avorenium.Infrastructure.Data.Migrations
{
    public partial class IssueWords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueWords",
                schema: "dbo",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp", maxLength: 3, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp", maxLength: 3, nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueWords", x => new { x.IssueId, x.WordId });
                    table.ForeignKey(
                        name: "FK_IssueWords_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "dbo",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueWords_Words_WordId",
                        column: x => x.WordId,
                        principalSchema: "dbo",
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueWords_WordId",
                schema: "dbo",
                table: "IssueWords",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueWords",
                schema: "dbo");
        }
    }
}
