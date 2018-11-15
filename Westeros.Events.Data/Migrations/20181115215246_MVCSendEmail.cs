using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class MVCSendEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "To",
                table: "MailDB",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "From",
                table: "MailDB",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "To",
                table: "MailDB",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "From",
                table: "MailDB",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
