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

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public CuisineType Cuisine { get; set; }
        public string Description { get; set; } 
        public int PrepTime { get; set; }
        public DifficultyType Difficulty { get; set; }
        public string PriceBar { get; set; }
        public string Image { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public ICollection<RecipeEntry> EntryRecipes { get; set; } = new List<RecipeEntry>();
        public ICollection<RecipeDevice> RecipeDevices { get; set; } = new List<RecipeDevice>();

        [NotMapped]
        List<string> _tags;
        [NotMapped]
        public List<string> Tag
        {
            get { return _tags ?? (_tags = GenerateTags()); }
        }


        public List<string> GetAllTags()
        {
            return _tags.ToList();    
        }

        List<string> GenerateTags()
        {
            var tags = new List<string>();


            foreach (var ing in RecipeIngredients)
            {
                tags.Add(ing.Ingredient.Name);
            }

            foreach (var dev in RecipeDevices)
            {
                tags.Add(dev.Device.Name);
            }


            var ingredients = RecipeIngredients.Select(i => i.Ingredient);
            tags.Add(CalculatePriceBar(ingredients));
            tags.Add(Difficulty.ToString());

            return tags;
        }

        string CalculatePriceBar(IEnumerable<Ingredient> ingredients)
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
