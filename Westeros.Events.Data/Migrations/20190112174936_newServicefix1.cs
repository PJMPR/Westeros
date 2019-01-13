using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class newServicefix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailServerDb");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MailDB",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MailDB");

            migrationBuilder.CreateTable(
                name: "MailServerDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    Topic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailServerDb", x => x.Id);
                });
        }
    }
}
