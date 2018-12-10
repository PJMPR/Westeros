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
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DietDatabase;Integrated Security=True;");
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<RecipeDevice> RecipeDevices { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<IngredientEntry> EntryIngredients { get; set; }
        public DbSet<RecipeEntry> EntryRecipes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredients>().HasKey(p => new {p.IngredientId, p.RecipeId});

            modelBuilder.Entity<Device>().HasData(
                new { Id = 1, Name = "Mikrofalówka"},
                new { Id = 2, Name = "Talerz"},
                new { Id = 3, Name = "Widelec"},
                new { Id = 4, Name = "Garnek"},
                new { Id = 5, Name = "Patelnia"},
                new { Id = 6, Name = "Wok"});

            modelBuilder.Entity<Ingredient>().HasData(
                new { Id = 1, Name = "Wołowina", Category = CategoryType.Meat, Calories = 250, Fats = 15.0, Carbohydrates = 0.0, Proteins = 26.0, AveragePrice = 3.5},
                new { Id = 2, Name = "Ser", Category = CategoryType.Dairy, Calories = 402, Fats = 33.0, Carbohydrates = 1.3, Proteins = 25.0, AveragePrice = 1.0 },
                new { Id = 3, Name = "Drób", Category = CategoryType.Meat, Calories = 272, Fats = 25.0, Carbohydrates = 0.0, Proteins = 11.0, AveragePrice = 1.5 },
                new { Id = 4, Name = "Łosoś", Category = CategoryType.Fish, Calories = 208, Fats = 12.0, Carbohydrates = 0.0, Proteins = 20.0, AveragePrice = 4.0 },
                new { Id = 5, Name = "Winogrona", Category = CategoryType.Fruit, Calories = 66, Fats = 0.4, Carbohydrates = 17.0, Proteins = 0.6, AveragePrice = 0.8 });
        }
    }
}
