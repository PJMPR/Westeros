using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class LogChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailDB_Profiles_ReceiverId",
                table: "MailDB");

            migrationBuilder.DropForeignKey(
                name: "FK_MailDB_Profiles_SenderId",
                table: "MailDB");

            migrationBuilder.DropIndex(
                name: "IX_MailDB_ReceiverId",
                table: "MailDB");

            migrationBuilder.DropIndex(
                name: "IX_MailDB_SenderId",
                table: "MailDB");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "MailDB");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "MailDB");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "LogDb");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "LogDb");

            migrationBuilder.DropColumn(
                name: "From",
                table: "LogDb");

            migrationBuilder.DropColumn(
                name: "To",
                table: "LogDb");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "LogDb");

            migrationBuilder.AddColumn<int>(
                name: "messageId",
                table: "LogDb",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogDb_messageId",
                table: "LogDb",
                column: "messageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogDb_MailDB_messageId",
                table: "LogDb",
                column: "messageId",
                principalTable: "MailDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogDb_MailDB_messageId",
                table: "LogDb");

            migrationBuilder.DropIndex(
                name: "IX_LogDb_messageId",
                table: "LogDb");

            migrationBuilder.DropColumn(
                name: "messageId",
                table: "LogDb");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "MailDB",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "MailDB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "LogDb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "LogDb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "LogDb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "LogDb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "LogDb",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MailDB_ReceiverId",
                table: "MailDB",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MailDB_SenderId",
                table: "MailDB",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MailDB_Profiles_ReceiverId",
                table: "MailDB",
                column: "ReceiverId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailDB_Profiles_SenderId",
                table: "MailDB",
                column: "SenderId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
