using System;
using Westeros.Diet.Data.Model;
using Westeros.Diet.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Westeros.Diet.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DietDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var en = new Entry
                {
                    Date = DateTime.Now,
                    UserProfileId = 1
                };

                context.Entries.Add(en);
                context.SaveChanges();

                ICollection<EntryIngredient> ing = new List<EntryIngredient>();
                ICollection<EntryRecipe> rec = new List<EntryRecipe>();

                foreach (var item in context.Recipes.ToList())
                {
                    rec.Add(new EntryRecipe
                    {
                        RecipeId = item.Id,
                        Entry = en,
                        EntryId = en.Id
                    });
                }

                context.EntryRecipes.Add(rec);
                context.SaveChanges();

                foreach (var item in context.Ingredients.Where(i => i.Id > 2))
                {
                    ing.Add(new EntryIngredient
                    {
                        IngredientId = item.Id,
                        IngredientQuantity = 2,
                        Entry = en,
                        EntryId = en.Id
                    });
                }

                context.Add(ing);
                context.SaveChanges();

                Console.WriteLine("Hello World!");
                Console.ReadKey();
            }
        }
    }
}
