using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Recipes.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Cuisine", "Description", "Difficulty", "Fats", "IsNew", "Name", "PhotoPath", "PrepTime", "PriceBar", "Proteins" },
                values: new object[] { 1, 0.0, 0.0, 0, null, 0, 0.0, true, "Kotlet Chedar", null, 0, null, 0.0 });

            migrationBuilder.InsertData(
                table: "RecipeDevices",
                columns: new[] { "Id", "DeviceId", "RecipeId" },
                values: new object[] { 1, 5, 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Id" },
                values: new object[] { 2, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeDevices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
