using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class newLogChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogDb_MailDB_messageId",
                table: "LogDb");

            migrationBuilder.RenameColumn(
                name: "messageId",
                table: "LogDb",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_LogDb_messageId",
                table: "LogDb",
                newName: "IX_LogDb_MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogDb_MailDB_MessageId",
                table: "LogDb",
                column: "MessageId",
                principalTable: "MailDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogDb_MailDB_MessageId",
                table: "LogDb");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "LogDb",
                newName: "messageId");

            migrationBuilder.RenameIndex(
                name: "IX_LogDb_MessageId",
                table: "LogDb",
                newName: "IX_LogDb_messageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogDb_MailDB_messageId",
                table: "LogDb",
                column: "messageId",
                principalTable: "MailDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
