using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Data.Model
{
    public enum CuisineType
    {
        Polish,
        Italian,
        Spanish,
        French,
        Scandinavian,
        Hungarian,
        Arabic,
        African,
        Thai,
        Japanese,
        Chinese,
        Russian,
        American,
        Other
    };

    public enum DifficultyType
    {
        Amateur,
        Easy,
        Medium,
        Hard,
        Masterchef
    };

    public class Recipe //: IIngredient
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Calories { get; private set; }
        public double Proteins { get; private set; }
        public double Carbohydrates { get; private set; }
        public double Fats { get; private set; }
        public CuisineType Cuisine { get; private set; }
        public string Description { get; private set; } 
        public int PrepTime { get; private set; }
        public DifficultyType Difficulty { get; private set; }
        public string PriceBar { get; private set; }
        public string Image { get; private set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
        public ICollection<EntryRecipe> EntryRecipes { get; set; }

        [NotMapped]
        public ICollection<string> devices { get; private set; }
        [NotMapped]
        public List<string> tags { get; private set; }


        public Recipe(int id, string name, int calories, double proteins, double carbohydrates, double fats, CuisineType cuisine, string description, int prepTime, DifficultyType difficulty, string priceBar, string image/*, ICollection<string> devices, ICollection<Ingredient> Ingredients, ICollection<string> tags*/)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Proteins = proteins;
            Carbohydrates = carbohydrates;
            Fats = fats;
            Cuisine = cuisine;
            Description = description;
            PrepTime = prepTime;
            Difficulty = difficulty;
            PriceBar = priceBar;
            Image = image;
            //this.devices = devices;
            //this.Ingredients = Ingredients;
            GenerateTags();
        }

        private void GenerateTags()
        {
            GetAllIngredients().ForEach(x => tags.Add(x.Name));
            devices.ToList().ForEach(tags.Add);
            tags.Add(Cuisine.ToString());
            tags.Add(Difficulty.ToString());
            tags.Add(PriceBar);
        }

        public List<string> GetAllTags()
        {
            return tags.ToList();    
        }

        public List<Ingredient> GetAllIngredients()
        {
            return IngredientRecipes.Select(x => x.Ingredient).ToList();
        }

        public static Recipe GetRecipe(int id)
        {
            using (var context = new DietDbContext())
            {
                var rex = context.Recipe.Single(r => r.Id == id);
                var ir = context.IngredientRecipes
                    .Where(x => x.RecipeId == id)
                    .Include(p => p.Recipe)
                    .Include(x => x.Ingredient).ToList();

                rex.IngredientRecipes = ir;
                return rex;
            }
        }

        public static List<Recipe> GetAllRecipes()
        {
            using (var context = new DietDbContext())
            {
                return context.Recipe.ToList();
            }
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Calories} {Fats} {Carbohydrates} {Proteins} {Image} ";
        }
    }
}
