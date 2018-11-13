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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipesDatabase;Integrated Security=True;");
        }

        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Device> Devices { get; set; }
                
    }
}
