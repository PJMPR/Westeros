using System;
using System.Linq;
using Westeros.Recipes.Data;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

namespace Westeros.Recipes.Service
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new RecipesDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Hello World!");
                Console.ReadKey();
            }
        }
    }
}
