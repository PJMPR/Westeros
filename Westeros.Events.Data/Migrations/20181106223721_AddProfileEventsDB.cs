using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class AddProfileEventsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "MailDB",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "MailDB",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
