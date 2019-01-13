using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class newServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MailDB");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "MailDB");

            migrationBuilder.CreateTable(
                name: "MailServerDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    To = table.Column<string>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailServerDb", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailServerDb");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MailDB",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "MailDB",
                nullable: false,
                defaultValue: false);
        }
    }
}
