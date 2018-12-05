using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.UserProfile.Data.Migrations
{
    public partial class CreateTargeryanDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    login = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    age = table.Column<int>(nullable: true),
                    weight = table.Column<int>(nullable: true),
                    gender = table.Column<Gender>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
