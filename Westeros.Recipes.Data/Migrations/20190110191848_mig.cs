using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Recipes.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Proteins = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Calories = table.Column<double>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    AvgPrice = table.Column<double>(nullable: false)
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
                    Calories = table.Column<double>(nullable: false),
                    Proteins = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    Cuisine = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PrepTime = table.Column<int>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    PriceBar = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_RecipeDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDevice_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDevice_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    IngridientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngridientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_Id",
                        column: x => x.Id,
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
                    { 1, "Mikrofalówka" },
                    { 2, "Talerz" },
                    { 3, "Widelec" },
                    { 4, "Garnek" },
                    { 5, "Patelnia" },
                    { 6, "Wok" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "AveragePrice", "Calories", "Carbohydrates", "Category", "Fats", "Name", "PhotoPath", "Proteins" },
                values: new object[,]
                {
                    { 1, 3.5, 250.0, 0.0, 2, 15.0, "Wolowina", null, 26.0 },
                    { 2, 1.0, 402.0, 1.3, 4, 33.0, "Ser", null, 25.0 },
                    { 3, 1.5, 272.0, 0.0, 2, 25.0, "Drób", null, 11.0 },
                    { 4, 4.0, 208.0, 0.0, 3, 12.0, "Losos", null, 20.0 },
                    { 5, 0.8, 66.0, 17.0, 1, 0.4, "Winogrona", null, 0.6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDevice_DeviceId",
                table: "RecipeDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDevice_RecipeId",
                table: "RecipeDevices",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_Id",
                table: "RecipeIngredients",
                column: "Id");

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
