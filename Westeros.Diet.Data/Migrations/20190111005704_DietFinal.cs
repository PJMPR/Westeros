using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Westeros.Diet.Data.Migrations
{
    public partial class DietFinal : Migration
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "DietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false),
                    Proteins = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    UserProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietPlans_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    UserProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false),
                    EntryId = table.Column<int>(nullable: false),
                    IngredientQuantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryIngredients", x => new { x.IngredientId, x.EntryId });
                    table.UniqueConstraint("AK_EntryIngredients_EntryId_IngredientId", x => new { x.EntryId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_EntryIngredients_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryRecipes_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryRecipes_Recipes_RecipeId",
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
                    { 1, 3.5, 250, 0.0, 2, 15.0, "Wołowina", null, 26.0 },
                    { 2, 1.0, 402, 1.3, 4, 33.0, "Ser", null, 25.0 },
                    { 3, 1.5, 272, 0.0, 2, 25.0, "Drób", null, 11.0 },
                    { 4, 4.0, 208, 0.0, 3, 12.0, "Łosoś", null, 20.0 },
                    { 5, 0.8, 66, 17.0, 1, 0.4, "Winogrona", null, 0.6 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Cuisine", "Description", "Difficulty", "IsNew", "Name", "PhotoPath", "PrepTime" },
                values: new object[,]
                {
                    { 1, 0, null, 0, true, "Masa", null, 0 },
                    { 2, 0, null, 0, true, "Redukcja", null, 0 },
                    { 3, 0, null, 0, true, "Utrzymanie", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Age", "Email", "Height", "Login", "Name", "Sex", "Surname", "Weight" },
                values: new object[,]
                {
                    { 1, 18, "a@a.pl", 175.0, "xXxDragonSlayerxXx", "Jan", 0, "Sikora", 90.0 },
                    { 2, 22, "b@b.pl", 165.0, "KsIeZnIcZkA69", "Marta", 1, "Kawecik", 45.0 }
                });

            migrationBuilder.InsertData(
                table: "DietPlans",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Fats", "Name", "Proteins", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 2656, 295.8, 111.5, "Masa plan", 117.1, 1 },
                    { 2, 1528, 299.8, 31.5, "Redukcja plan", 81.1, 1 },
                    { 3, 2161, 24.8, 84.6, "Utrzymanie plan", 19.1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Date", "UserProfileId", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 10, 1, 57, 3, 913, DateTimeKind.Local), 1, 90.0 },
                    { 2, new DateTime(2019, 1, 10, 1, 57, 3, 915, DateTimeKind.Local), 1, 89.0 },
                    { 3, new DateTime(2019, 1, 11, 1, 57, 3, 915, DateTimeKind.Local), 1, 88.0 },
                    { 4, new DateTime(2019, 1, 10, 22, 57, 3, 915, DateTimeKind.Local), 2, 45.0 },
                    { 5, new DateTime(2019, 1, 11, 0, 57, 3, 915, DateTimeKind.Local), 2, 46.0 },
                    { 6, new DateTime(2019, 1, 11, 1, 57, 3, 915, DateTimeKind.Local), 2, 44.0 }
                });

            migrationBuilder.InsertData(
                table: "RecipeDevices",
                columns: new[] { "Id", "DeviceId", "RecipeId" },
                values: new object[,]
                {
                    { 8, 1, 3 },
                    { 9, 4, 3 },
                    { 5, 3, 2 },
                    { 4, 5, 2 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 6, 6, 3 },
                    { 1, 1, 1 },
                    { 7, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "IngredientQuantity" },
                values: new object[,]
                {
                    { 1, 3, 1.0 },
                    { 3, 3, 8.0 },
                    { 2, 3, 0.5 },
                    { 2, 1, 1.0 },
                    { 2, 2, 8.0 },
                    { 4, 1, 2.0 },
                    { 4, 3, 2.0 },
                    { 1, 1, 5.0 },
                    { 5, 2, 8.0 },
                    { 5, 3, 1.5 }
                });

            migrationBuilder.InsertData(
                table: "EntryIngredients",
                columns: new[] { "IngredientId", "EntryId", "IngredientQuantity" },
                values: new object[,]
                {
                    { 1, 1, 5.0 },
                    { 5, 2, 0.5 },
                    { 5, 4, 0.15 },
                    { 2, 4, 1.5 },
                    { 4, 6, 8.5 }
                });

            migrationBuilder.InsertData(
                table: "EntryRecipes",
                columns: new[] { "Id", "EntryId", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 3, 3 },
                    { 6, 4, 1 },
                    { 7, 4, 1 },
                    { 8, 5, 2 },
                    { 9, 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_UserProfileId",
                table: "DietPlans",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserProfileId",
                table: "Entries",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryRecipes_EntryId",
                table: "EntryRecipes",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryRecipes_RecipeId",
                table: "EntryRecipes",
                column: "RecipeId");

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
                name: "DietPlans");

            migrationBuilder.DropTable(
                name: "EntryIngredients");

            migrationBuilder.DropTable(
                name: "EntryRecipes");

            migrationBuilder.DropTable(
                name: "RecipeDevices");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
