using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Events.Data.Migrations
{
    public partial class RecipesDemoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Profiles");
        }
    }
}
