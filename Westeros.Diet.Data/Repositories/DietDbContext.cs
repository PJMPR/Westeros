using System;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Data.Repositories
{
    public class DietDbContext : DbContext
    {
        public DietDbContext() : base()
        {

        }

        public DietDbContext(DbContextOptions<DietDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DietDatabase;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<RecipeDevice> RecipeDevices { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<EntryIngredient> EntryIngredients { get; set; }
        public DbSet<EntryRecipe> EntryRecipes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntryIngredient>().HasKey(p => new { p.IngredientId, p.EntryId });
            modelBuilder.Entity<RecipeIngredient>().HasKey(p => new { p.IngredientId, p.RecipeId });

            #region Device
            var dev1 = new Device { Id = 1, Name = "Oven" };
            var dev2 = new Device { Id = 2, Name = "Plate" };
            var dev3 = new Device { Id = 3, Name = "Pan" };
            var dev4 = new Device { Id = 4, Name = "Cup" };
            var dev5 = new Device { Id = 5, Name = "Stove" };
            var dev6 = new Device { Id = 6, Name = "Toaster" };

            modelBuilder.Entity<Device>().HasData(dev1, dev2, dev3, dev4, dev5, dev6);
            #endregion

            #region Ingredient
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

            #endregion

            #region Recipe
            var rec1 = new Recipe
            {
                Id = 1,
                Name = "Ramen",
                PhotoPath = "http://images.kglobalservices.com/www.morningstarfarms.com/en_us/recipe/recipe_6540350/recip_img-6542859_banh_mi_ramen.jpg",
                PrepTime = 7,
                Difficulty = DifficultyType.Amateur,
                Description = "Use chicken, noodles, spinach, sweetcorn and eggs to make this moreish Japanese noodle soup, for when you crave something comforting yet light and wholesome"
            };
            var rec2 = new Recipe
            {
                Id = 2,
                Name = "Ratatoille",
                PhotoPath = "https://www.tasteofhome.com/wp-content/uploads/2017/10/exps9117_LM963641C27-2.jpg",
                PrepTime = 18,
                Difficulty = DifficultyType.Medium,
                Description = "This moreish Mediterranean-style vegetable stew is perfect for a super-healthy midweek supper."
            };
            var rec3 = new Recipe
            {
                Id = 3,
                Name = "Paella",
                PhotoPath = "https://www.tasteofhome.com/wp-content/uploads/2017/10/exps40641_HCA1383857D43.jpg",
                PrepTime = 45,
                Difficulty = DifficultyType.Hard,
                Description = "Whip up this easy version of the traditional Spanish seafood dish straight from the storecupboard. Add extras such as chorizo and peas if you like"
            };

            modelBuilder.Entity<Recipe>().HasData(rec1, rec2, rec3);
            #endregion

            #region RecipeDevice
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
            #endregion

            #region RecipeIngredient
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
            #endregion

            #region UserProfile
            var up1 = new UserProfile { Id = 1, Age = 18, Email = "a@a.pl", Height = 175, Name = "Jan", Surname = "Sikora", Weight = 90, Login = "xXxDragonSlayerxXx", Sex = Sex.Male };
            var up2 = new UserProfile { Id = 2, Age = 22, Email = "b@b.pl", Height = 165, Name = "Marta", Surname = "Kawecik", Weight = 45, Login = "KsIeZnIcZkA69", Sex = Sex.Female };

            modelBuilder.Entity<UserProfile>().HasData(up1, up2);
            #endregion

            #region Entry
            var ent1 = new Entry { Id = 1, UserProfileId = 1, Date = DateTime.Now.AddDays(-1), Weight = 90 };
            var ent2 = new Entry { Id = 2, UserProfileId = 1, Date = DateTime.Now.AddDays(-1), Weight = 89 };
            var ent3 = new Entry { Id = 3, UserProfileId = 1, Date = DateTime.Now, Weight = 88 };

            var ent4 = new Entry { Id = 4, UserProfileId = 2, Date = DateTime.Now.AddHours(-3), Weight = 45 };
            var ent5 = new Entry { Id = 5, UserProfileId = 2, Date = DateTime.Now.AddHours(-1), Weight = 46 };
            var ent6 = new Entry { Id = 6, UserProfileId = 2, Date = DateTime.Now, Weight = 44 };

            modelBuilder.Entity<Entry>().HasData(ent1, ent2, ent3, ent4, ent5, ent6);
            #endregion

            #region IngredientEntry
            var ie1 = new EntryIngredient { EntryId = 1, IngredientId = 1, IngredientQuantity = 5 };
            var ie2 = new EntryIngredient { EntryId = 2, IngredientId = 5, IngredientQuantity = 0.5 };

            var ie3 = new EntryIngredient { EntryId = 4, IngredientId = 5, IngredientQuantity = 0.15 };
            var ie4 = new EntryIngredient { EntryId = 4, IngredientId = 2, IngredientQuantity = 1.5 };
            var ie5 = new EntryIngredient { EntryId = 6, IngredientId = 4, IngredientQuantity = 8.5 };

            modelBuilder.Entity<EntryIngredient>().HasData(ie1, ie2, ie3, ie4, ie5);
            #endregion

            #region RecipeEntry
            var re1 = new EntryRecipe { Id = 1, EntryId = 1, RecipeId = 2 };
            var re2 = new EntryRecipe { Id = 2, EntryId = 1, RecipeId = 2 };
            var re3 = new EntryRecipe { Id = 3, EntryId = 2, RecipeId = 2 };
            var re4 = new EntryRecipe { Id = 4, EntryId = 2, RecipeId = 3 };
            var re5 = new EntryRecipe { Id = 5, EntryId = 3, RecipeId = 3 };

            var re6 = new EntryRecipe { Id = 6, EntryId = 4, RecipeId = 1 };
            var re7 = new EntryRecipe { Id = 7, EntryId = 4, RecipeId = 1 };
            var re8 = new EntryRecipe { Id = 8, EntryId = 5, RecipeId = 2 };
            var re9 = new EntryRecipe { Id = 9, EntryId = 6, RecipeId = 2 };

            modelBuilder.Entity<EntryRecipe>().HasData(re1, re2, re3, re4, re5, re6, re7, re8, re9);
            #endregion

            #region DietPlan
            var dp1 = new DietPlan { Id = 1, Name = "Masa plan", Calories = 2656, Proteins = 117.1, Carbohydrates = 295.8, Fats = 111.5, UserProfileId = 1 };
            var dp2 = new DietPlan { Id = 2, Name = "Redukcja plan", Calories = 1528, Proteins = 81.1, Carbohydrates = 299.8, Fats = 31.5, UserProfileId = 1 };
            var dp3 = new DietPlan { Id = 3, Name = "Utrzymanie plan", Calories = 2161, Proteins = 19.1, Carbohydrates = 24.8, Fats = 84.6, UserProfileId = 1 };

            modelBuilder.Entity<DietPlan>().HasData(dp1, dp2, dp3);
            #endregion
        }
    }
}
