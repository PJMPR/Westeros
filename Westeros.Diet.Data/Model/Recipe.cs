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
        //public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
        public ICollection<EntryRecipe> EntryRecipes { get; set; }
        public ICollection<RecipeDevice> RecipeDevices { get; set; } 

        [NotMapped]
        private List<string> _tags;
        [NotMapped]
        public List<string> Tag
        {
            get { return _tags /*?? (_tags = GenerateTags())*/; }
        }


        public List<string> GetAllTags()
        {
            return _tags.ToList();    
        }

        //public List<Ingredient> GetAllIngredients()
        //{
        //    return IngredientRecipes.Select(x => x.Ingredient).ToList();
        //}

        //public static Recipe GetRecipe(int id)
        //{
        //    using (var context = new DietDbContext())
        //    {
        //        var rex = context.Recipe.Single(r => r.Id == id);
        //        var ir = context.IngredientRecipes
        //            .Where(x => x.RecipeId == id)
        //            .Include(p => p.Recipe)
        //            .Include(x => x.Ingredient).ToList();

        //        rex.IngredientRecipes = ir;
        //        return rex;
        //    }
        //}

        public static List<Recipe> GetAllRecipes()
        {
            using (var context = new DietDbContext())
            {
                return context.Recipe.ToList();
            }
        }

        //public List<string> GenerateTags()
        //{
        //    var tags = new List<string>();

        //    foreach (Ingredient ing in IngredientRecipes)
        //    {
        //        tags.Add(ing.Name);
        //    }

        //    foreach (var dev in RecipeDevices)
        //    {
        //        tags.Add(dev.Name);
        //    }

        //    tags.Add(CalculatePriceBar(Ingredients));
        //    tags.Add(Difficulty.ToString());

        //    return tags;
        //}

        private string CalculatePriceBar(ICollection<Ingredient> ingredients)
        {
            double Price = 0;

            foreach (Ingredient ing in ingredients)
            {
                Price += ing.AveragePrice;
            }

            if (Price < 10) return "Bardzo tanie";
            else if (Price >= 10 && Price < 15) return "Tanie";
            else if (Price >= 15 && Price < 25) return "Œrenio drogie";
            else if (Price >= 25 && Price < 40) return "Drogie";
            else return "Bardzo drogie";
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Calories} {Fats} {Carbohydrates} {Proteins} {Image} ";
        }
    }
}
