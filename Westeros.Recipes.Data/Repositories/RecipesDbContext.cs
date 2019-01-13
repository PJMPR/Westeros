using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Recipes.Data.Model;

namespace Westeros.Recipes.Data.Repositories
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext():base()
        {
            
        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipesDatabase;Integrated Security=True;");
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<RecipeDevice> RecipeDevices { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>().HasKey(p => new { IngridientId = p.IngredientId, p.RecipeId });

            var dev1 = new Device { Id = 1, Name = "Oven"};
            var dev2 = new Device { Id = 2, Name = "Plate" };
            var dev3 = new Device { Id = 3, Name = "Pan" };
            var dev4 = new Device { Id = 4, Name = "Cup" };
            var dev5 = new Device { Id = 5, Name = "Stove" };
            var dev6 = new Device { Id = 6, Name = "Toaster" };

            modelBuilder.Entity<Device>().HasData(dev1, dev2, dev3, dev4, dev5, dev6);

            var ing1 = new Ingredient { Id = 1, Name = "Chicken Stock", Category = CategoryType.Meat, Calories = 250, Fats = 15.0, Carbohydrates = 0.0, Proteins = 26.0, AveragePrice = 3.5 };
            var ing2 = new Ingredient { Id = 2, Name = "Baby spinach", Category = CategoryType.Vegetable, Calories = 402, Fats = 33.0, Carbohydrates = 1.3, Proteins = 25.0, AveragePrice = 1.0 };
            var ing3 = new Ingredient { Id = 3, Name = "Ramen noodles", Category = CategoryType.Delicacies, Calories = 272, Fats = 25.0, Carbohydrates = 0.0, Proteins = 11.0, AveragePrice = 1.5 };
            var ing4 = new Ingredient { Id = 4, Name = "Sliced cooked pork", Category = CategoryType.Meat, Calories = 208, Fats = 12.0, Carbohydrates = 0.0, Proteins = 20.0, AveragePrice = 4.0 };
            var ing5 = new Ingredient { Id = 5, Name = "Red onion", Category = CategoryType.Vegetable, Calories = 66, Fats = 0.4, Carbohydrates = 17.0, Proteins = 0.6, AveragePrice = 0.8 };
            var ing6 = new Ingredient { Id = 6, Name = "Garlic", Category = CategoryType.Vegetable, Calories = 16, Fats = 0.2, Carbohydrates = 7.0, Proteins = 0.6, AveragePrice = 2 };
            var ing7 = new Ingredient { Id = 7, Name = "Red pepper", Category = CategoryType.Vegetable, Calories = 19, Fats = 0.1, Carbohydrates = 1.0, Proteins = 0.6, AveragePrice = 0.8 };
            var ing8 = new Ingredient { Id = 8, Name = "Olive oil", Category = CategoryType.Other, Calories = 80, Fats = 0.4, Carbohydrates = 17.0, Proteins = 0.6, AveragePrice = 0.8 };
            var ing9 = new Ingredient { Id = 9, Name = "Parsley", Category = CategoryType.Other, Calories = 20, Fats = 0.4, Carbohydrates = 17.0, Proteins = 0.6, AveragePrice = 0.8 };
            var ing10 = new Ingredient { Id = 10, Name = "Chorizo sausage", Category = CategoryType.Other, Calories = 120, Fats = 0.4, Carbohydrates = 17.0, Proteins = 0.6, AveragePrice = 0.8 };
            modelBuilder.Entity<Ingredient>().HasData(ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10);

            var rec1 = new Recipe { Id = 1, Name = "Ramen",
                PhotoPath = "http://images.kglobalservices.com/www.morningstarfarms.com/en_us/recipe/recipe_6540350/recip_img-6542859_banh_mi_ramen.jpg",
                PrepTime = 7 ,
                Difficulty = DifficultyType.Amateur,
                Description = "Use chicken, noodles, spinach, sweetcorn and eggs to make this moreish Japanese noodle soup, for when you crave something comforting yet light and wholesome"
            };
            var rec2 = new Recipe { Id = 2, Name = "Ratatoille",
                PhotoPath = "https://www.tasteofhome.com/wp-content/uploads/2017/10/exps9117_LM963641C27-2.jpg",
                PrepTime = 18 ,
                Difficulty = DifficultyType.Medium,
                Description = "This moreish Mediterranean-style vegetable stew is perfect for a super-healthy midweek supper."
            };
            var rec3 = new Recipe { Id = 3, Name = "Paella",
                PhotoPath = "https://www.tasteofhome.com/wp-content/uploads/2017/10/exps40641_HCA1383857D43.jpg",
                PrepTime = 45 ,
                Difficulty = DifficultyType.Hard,
                Description = "Whip up this easy version of the traditional Spanish seafood dish straight from the storecupboard. Add extras such as chorizo and peas if you like"
            };

            modelBuilder.Entity<Recipe>().HasData(rec1, rec2, rec3);

            var rd1 = new RecipeDevice { Id = 1, RecipeId = 1, DeviceId = 1 };
            var rd2 = new RecipeDevice { Id = 2, RecipeId = 1, DeviceId = 2 };
            var rd3 = new RecipeDevice { Id = 3, RecipeId = 1, DeviceId = 3 };

            var rd4 = new RecipeDevice { Id = 4, RecipeId = 2, DeviceId = 5 };
            var rd5 = new RecipeDevice { Id = 5, RecipeId = 2, DeviceId = 3 };

            var rd6 = new RecipeDevice { Id = 6, RecipeId = 3, DeviceId = 6 };
            var rd7 = new RecipeDevice { Id = 7, RecipeId = 3, DeviceId = 2 };
            var rd8 = new RecipeDevice { Id = 8, RecipeId = 3, DeviceId = 1 };
            var rd9 = new RecipeDevice { Id = 9, RecipeId = 3, DeviceId = 4 };

            modelBuilder.Entity<RecipeDevice>().HasData(rd1, rd2, rd3, rd4, rd5, rd6, rd7, rd8, rd9);

            var ingRec1 = new RecipeIngredient { RecipeId = 1, IngredientId = 1, IngredientQuantity = 5 };
            var ingRec2 = new RecipeIngredient { RecipeId = 1, IngredientId = 2, IngredientQuantity = 1 };
            var ingRec3 = new RecipeIngredient { RecipeId = 1, IngredientId = 3, IngredientQuantity = 2 };
            var ingRec11 = new RecipeIngredient { RecipeId = 1, IngredientId = 4, IngredientQuantity = 2 };

            var ingRec4 = new RecipeIngredient { RecipeId = 2, IngredientId = 6, IngredientQuantity = 8 };
            var ingRec5 = new RecipeIngredient { RecipeId = 2, IngredientId = 5, IngredientQuantity = 8 };
            var ingRec12 = new RecipeIngredient { RecipeId = 2, IngredientId = 7, IngredientQuantity = 8 };
            var ingRec13 = new RecipeIngredient { RecipeId = 2, IngredientId = 8, IngredientQuantity = 8 };

            var ingRec6 = new RecipeIngredient { RecipeId = 3, IngredientId = 4, IngredientQuantity = 1 };
            var ingRec7 = new RecipeIngredient { RecipeId = 3, IngredientId = 6, IngredientQuantity = 0.5 };
            var ingRec8 = new RecipeIngredient { RecipeId = 3, IngredientId = 9, IngredientQuantity = 8 };
            var ingRec9 = new RecipeIngredient { RecipeId = 3, IngredientId = 10, IngredientQuantity = 2 };
            var ingRec10 = new RecipeIngredient { RecipeId = 3, IngredientId = 8, IngredientQuantity = 1.5 };

            modelBuilder.Entity<RecipeIngredient>().HasData(ingRec1, ingRec2, ingRec3, ingRec4, ingRec5, ingRec6, ingRec7, ingRec8, ingRec9, ingRec10, ingRec11, ingRec12, ingRec13);
           
        }
    }
}
