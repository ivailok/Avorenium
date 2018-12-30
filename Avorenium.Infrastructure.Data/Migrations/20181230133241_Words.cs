using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Avorenium.Infrastructure.Data.Migrations
{
    public partial class Words : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp", maxLength: 3, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp", maxLength: 3, nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp", maxLength: 3, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp", maxLength: 3, nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_WordTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "WordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_Text",
                schema: "dbo",
                table: "Words",
                column: "Text",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_TypeId",
                schema: "dbo",
                table: "Words",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WordTypes_Text",
                schema: "dbo",
                table: "WordTypes",
                column: "Text",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WordTypes",
                schema: "dbo");
        }
    }
}
