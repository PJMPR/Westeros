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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DietDatabase;Integrated Security=True;");
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<RecipeDevice> RecipeDevices { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<IngredientEntry> EntryIngredients { get; set; }
        public DbSet<RecipeEntry> EntryRecipes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntry>().HasKey(p => new { p.IngredientId, p.EntryId });
            modelBuilder.Entity<RecipeIngredient>().HasKey(p => new { p.IngredientId, p.RecipeId });

            var dev1 = new Device { Id = 1, Name = "Mikrofalówka" };
            var dev2 = new Device { Id = 2, Name = "Talerz" };
            var dev3 = new Device { Id = 3, Name = "Widelec" };
            var dev4 = new Device { Id = 4, Name = "Garnek" };
            var dev5 = new Device { Id = 5, Name = "Patelnia" };
            var dev6 = new Device { Id = 6, Name = "Wok" };

            modelBuilder.Entity<Device>().HasData(dev1, dev2, dev3, dev4, dev5, dev6);

            var ing1 = new Ingredient { Id = 1, Name = "Wołowina", Category = CategoryType.Meat, Calories = 250, Fats = 15.0, Carbohydrates = 0.0, Proteins = 26.0, AveragePrice = 3.5 };
            var ing2 = new Ingredient { Id = 2, Name = "Ser", Category = CategoryType.Dairy, Calories = 402, Fats = 33.0, Carbohydrates = 1.3, Proteins = 25.0, AveragePrice = 1.0 };
            var ing3 = new Ingredient { Id = 3, Name = "Drób", Category = CategoryType.Meat, Calories = 272, Fats = 25.0, Carbohydrates = 0.0, Proteins = 11.0, AveragePrice = 1.5 };
            var ing4 = new Ingredient { Id = 4, Name = "Łosoś", Category = CategoryType.Fish, Calories = 208, Fats = 12.0, Carbohydrates = 0.0, Proteins = 20.0, AveragePrice = 4.0 };
            var ing5 = new Ingredient { Id = 5, Name = "Winogrona", Category = CategoryType.Fruit, Calories = 66, Fats = 0.4, Carbohydrates = 17.0, Proteins = 0.6, AveragePrice = 0.8 };

            modelBuilder.Entity<Ingredient>().HasData(ing1, ing2, ing3, ing4, ing5);

            var rec1 = new Recipe { Id = 1, Name = "Masa" };
            var rec2 = new Recipe { Id = 2, Name = "Redukcja" };
            var rec3 = new Recipe { Id = 3, Name = "Utrzymanie" };

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
            var ingRec3 = new RecipeIngredient { RecipeId = 1, IngredientId = 4, IngredientQuantity = 2 };

            var ingRec4 = new RecipeIngredient { RecipeId = 2, IngredientId = 2, IngredientQuantity = 8 };
            var ingRec5 = new RecipeIngredient { RecipeId = 2, IngredientId = 5, IngredientQuantity = 8 };

            var ingRec6 = new RecipeIngredient { RecipeId = 3, IngredientId = 1, IngredientQuantity = 1 };
            var ingRec7 = new RecipeIngredient { RecipeId = 3, IngredientId = 2, IngredientQuantity = 0.5 };
            var ingRec8 = new RecipeIngredient { RecipeId = 3, IngredientId = 3, IngredientQuantity = 8 };
            var ingRec9 = new RecipeIngredient { RecipeId = 3, IngredientId = 4, IngredientQuantity = 2 };
            var ingRec10 = new RecipeIngredient { RecipeId = 3, IngredientId = 5, IngredientQuantity = 1.5 };

            modelBuilder.Entity<RecipeIngredient>().HasData(ingRec1, ingRec2, ingRec3, ingRec4, ingRec5, ingRec6, ingRec7, ingRec8, ingRec9, ingRec10);

            var up1 = new UserProfile { Id = 1, Age = 18, Email = "a@a.pl", Height = 175, Name = "Jan", Surname = "Sikora", Weight = 90, Login = "xXxDragonSlayerxXx", Sex = Sex.Male };
            var up2 = new UserProfile { Id = 2, Age = 22, Email = "b@b.pl", Height = 165, Name = "Marta", Surname = "Kawecik", Weight = 45, Login = "KsIeZnIcZkA69", Sex = Sex.Female };

            modelBuilder.Entity<UserProfile>().HasData(up1, up2);

            var ent1 = new Entry { Id = 1, UserProfileId = 1, Date = DateTime.Now.AddDays(-1), Weight = 90 };
            var ent2 = new Entry { Id = 2, UserProfileId = 1, Date = DateTime.Now.AddDays(-1), Weight = 89 };
            var ent3 = new Entry { Id = 3, UserProfileId = 1, Date = DateTime.Now, Weight = 88 };

            var ent4 = new Entry { Id = 4, UserProfileId = 2, Date = DateTime.Now.AddHours(-3), Weight = 45 };
            var ent5 = new Entry { Id = 5, UserProfileId = 2, Date = DateTime.Now.AddHours(-1), Weight = 46 };
            var ent6 = new Entry { Id = 6, UserProfileId = 2, Date = DateTime.Now, Weight = 44 };

            modelBuilder.Entity<Entry>().HasData(ent1, ent2, ent3, ent4, ent5, ent6);

            var ie1 = new IngredientEntry { EntryId = 1, IngredientId = 1, IngredientQuantity = 5 };
            var ie2 = new IngredientEntry { EntryId = 2, IngredientId = 5, IngredientQuantity = 0.5 };

            var ie3 = new IngredientEntry { EntryId = 4, IngredientId = 5, IngredientQuantity = 0.15 };
            var ie4 = new IngredientEntry { EntryId = 4, IngredientId = 2, IngredientQuantity = 1.5 };
            var ie5 = new IngredientEntry { EntryId = 6, IngredientId = 4, IngredientQuantity = 8.5 };

            modelBuilder.Entity<IngredientEntry>().HasData(ie1, ie2, ie3, ie4, ie5);

            var re1 = new RecipeEntry { Id = 1, EntryId = 1, RecipeId = 2 };
            var re2 = new RecipeEntry { Id = 2, EntryId = 1, RecipeId = 2 };
            var re3 = new RecipeEntry { Id = 3, EntryId = 2, RecipeId = 2 };
            var re4 = new RecipeEntry { Id = 4, EntryId = 2, RecipeId = 3 };
            var re5 = new RecipeEntry { Id = 5, EntryId = 3, RecipeId = 3 };

            var re6 = new RecipeEntry { Id = 6, EntryId = 4, RecipeId = 1 };
            var re7 = new RecipeEntry { Id = 7, EntryId = 4, RecipeId = 1 };
            var re8 = new RecipeEntry { Id = 8, EntryId = 5, RecipeId = 2 };
            var re9 = new RecipeEntry { Id = 9, EntryId = 6, RecipeId = 2 };

            modelBuilder.Entity<RecipeEntry>().HasData(re1, re2, re3, re4, re5, re6, re7, re8, re9);

        }
    }
}
