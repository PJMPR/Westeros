using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Recipes.Data.Migrations
{
    public partial class MigracjaFilip01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<int>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    Proteins = table.Column<double>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AveragePrice = table.Column<double>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    Cuisine = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PrepTime = table.Column<int>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDevices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDevices_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    IngredientQuantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oven" },
                    { 2, "Plate" },
                    { 3, "Pan" },
                    { 4, "Cup" },
                    { 5, "Stove" },
                    { 6, "Toaster" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "AveragePrice", "Calories", "Carbohydrates", "Category", "Fats", "Name", "PhotoPath", "Proteins" },
                values: new object[,]
                {
                    { 10, 0.8, 120, 17.0, 6, 0.4, "Chorizo sausage", null, 0.6 },
                    { 9, 0.8, 20, 17.0, 6, 0.4, "Parsley", null, 0.6 },
                    { 8, 0.8, 80, 17.0, 6, 0.4, "Olive oil", null, 0.6 },
                    { 7, 0.8, 19, 1.0, 0, 0.1, "Red pepper", null, 0.6 },
                    { 6, 2.0, 16, 7.0, 0, 0.2, "Garlic", null, 0.6 },
                    { 4, 4.0, 208, 0.0, 2, 12.0, "Sliced cooked pork", null, 20.0 },
                    { 3, 1.5, 272, 0.0, 5, 25.0, "Ramen noodles", null, 11.0 },
                    { 2, 1.0, 402, 1.3, 0, 33.0, "Baby spinach", null, 25.0 },
                    { 1, 3.5, 250, 0.0, 2, 15.0, "Chicken Stock", null, 26.0 },
                    { 5, 0.8, 66, 17.0, 0, 0.4, "Red onion", null, 0.6 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Cuisine", "Description", "Difficulty", "IsNew", "Name", "PhotoPath", "PrepTime" },
                values: new object[,]
                {
                    { 2, 0, "This moreish Mediterranean-style vegetable stew is perfect for a super-healthy midweek supper.", 2, true, "Ratatoille", "https://www.tasteofhome.com/wp-content/uploads/2017/10/exps9117_LM963641C27-2.jpg", 18 },
                    { 1, 0, "Use chicken, noodles, spinach, sweetcorn and eggs to make this moreish Japanese noodle soup, for when you crave something comforting yet light and wholesome", 0, true, "Ramen", "http://images.kglobalservices.com/www.morningstarfarms.com/en_us/recipe/recipe_6540350/recip_img-6542859_banh_mi_ramen.jpg", 7 },
                    { 3, 0, "Whip up this easy version of the traditional Spanish seafood dish straight from the storecupboard. Add extras such as chorizo and peas if you like", 3, true, "Paella", "https://www.tasteofhome.com/wp-content/uploads/2017/10/exps40641_HCA1383857D43.jpg", 45 }
                });

            migrationBuilder.InsertData(
                table: "RecipeDevices",
                columns: new[] { "Id", "DeviceId", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 9, 4, 3 },
                    { 4, 5, 2 },
                    { 5, 3, 2 },
                    { 8, 1, 3 },
                    { 7, 2, 3 },
                    { 6, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "IngredientQuantity" },
                values: new object[,]
                {
                    { 9, 3, 8.0 },
                    { 6, 3, 0.5 },
                    { 4, 3, 1.0 },
                    { 5, 2, 8.0 },
                    { 7, 2, 8.0 },
                    { 10, 3, 2.0 },
                    { 6, 2, 8.0 },
                    { 4, 1, 2.0 },
                    { 3, 1, 2.0 },
                    { 2, 1, 1.0 },
                    { 1, 1, 5.0 },
                    { 8, 2, 8.0 },
                    { 8, 3, 1.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDevices_DeviceId",
                table: "RecipeDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDevices_RecipeId",
                table: "RecipeDevices",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeDevices");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
