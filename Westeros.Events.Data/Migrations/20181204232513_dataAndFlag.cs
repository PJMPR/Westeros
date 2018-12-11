using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class dataAndFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "MailDB",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReadFlag",
                table: "MailDB",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadFlag",
                table: "MailDB");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "MailDB",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
