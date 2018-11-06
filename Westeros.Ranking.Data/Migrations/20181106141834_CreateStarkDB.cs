using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Ranking.Data.Migrations
{
    public partial class CreateStarkDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietyOdwiedziny",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DietaId = table.Column<int>(nullable: false),
                    IloscOdwiedzin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietyOdwiedziny", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Komentarz",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Tekst = table.Column<string>(nullable: true),
                    Nick = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentarz", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrzepisyOdwiedziny",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrzepisId = table.Column<int>(nullable: false),
                    IloscOdwiedzin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzepisyOdwiedziny", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietyOdwiedziny");

            migrationBuilder.DropTable(
                name: "Komentarz");

            migrationBuilder.DropTable(
                name: "PrzepisyOdwiedziny");
        }
    }
}
