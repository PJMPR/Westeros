using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Westeros.Ranking.Data.Migrations
{
    public partial class StarkDataBase : Migration
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
                name: "Oceny",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Nick = table.Column<string>(nullable: false),
                    Ocena = table.Column<int>(nullable: false),
                    Tekst = table.Column<string>(nullable: false),
                    resourceId = table.Column<int>(nullable: false),
                    resourceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oceny", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrzepisyOdwiedziny",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IloscOdwiedzin = table.Column<int>(nullable: false),
                    PrzepisId = table.Column<int>(nullable: false)
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
                name: "Oceny");

            migrationBuilder.DropTable(
                name: "PrzepisyOdwiedziny");
        }
    }
}
