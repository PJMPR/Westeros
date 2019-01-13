using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class LogModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogDb_MailDB_MessageId",
                table: "LogDb");

            migrationBuilder.AddForeignKey(
                name: "FK_LogDb_MailServerDb_MessageId",
                table: "LogDb",
                column: "MessageId",
                principalTable: "MailServerDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogDb_MailServerDb_MessageId",
                table: "LogDb");

            migrationBuilder.AddForeignKey(
                name: "FK_LogDb_MailDB_MessageId",
                table: "LogDb",
                column: "MessageId",
                principalTable: "MailDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
