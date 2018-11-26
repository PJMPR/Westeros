using Microsoft.EntityFrameworkCore;
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

        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        public DbSet<EntryIngredient> EntryIngredients { get; set; }
        public DbSet<EntryRecipe> EntryRecipes { get; set; }
        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IngredientRecipe>()
            //    .HasKey(x => x.Id);
        }
    }
}
