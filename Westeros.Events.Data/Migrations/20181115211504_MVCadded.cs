using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class MVCadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Profiles_NickName",
                table: "Profiles",
                column: "NickName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Profiles_NickName",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
