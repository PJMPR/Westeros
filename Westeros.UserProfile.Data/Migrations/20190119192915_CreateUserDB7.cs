using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Westeros.UserProfile.Data.Migrations
{
    public partial class CreateUserDB7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipe_RecipeID",
                table: "UserRecipe",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_Recipe_RecipeID",
                table: "UserRecipe",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_Recipe_RecipeID",
                table: "UserRecipe");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_UserRecipe_RecipeID",
                table: "UserRecipe");
        }
    }
}
