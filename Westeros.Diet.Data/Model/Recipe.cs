using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Data
{
    public enum DifficultyType
    {
        Amateur,
        Easy,
        Medium,
        Hard,
        Masterchef
    };

    public enum CuisineType
    {
        Polish,
        talian,
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

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public double Calories => CaloriesCalc();
        [NotMapped]
        public double Proteins => ProteinsCalc();
        [NotMapped]
        public double Carbohydrates => CarbsCalc();
        [NotMapped]
        public double Fats => FatsCalc();
        public Boolean IsNew { get; set; } = true;
        public CuisineType Cuisine { get; set; }
        public string Description { get; set; }
        public int PrepTime { get; set; }
        public DifficultyType Difficulty { get; set; }
        [NotMapped]
        public string PriceBar => CalculatePriceBar();
        public string PhotoPath { get; set; }
        [NotMapped]
        public List<string> Tag => GenerateTags();
        public ICollection<RecipeDevice> RecipeDevices { get; set; } = new HashSet<RecipeDevice>();
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();


        public Recipe NewInstance()
        {
            return new Recipe();
        }

        private double CaloriesCalc()
        {
            double sumCalories = 0;

            foreach (var ing in RecipeIngredients)
            {
                sumCalories += ing.Ingredient.Calories;
            }

            return sumCalories;
        }

        private double ProteinsCalc()
        {
            double sumProteins = 0;

            foreach (var ing in RecipeIngredients)
            {
                sumProteins += ing.Ingredient.Proteins;
            }

            return sumProteins;
        }

        private double CarbsCalc()
        {
            double sumCarbs = 0;

            foreach (var ing in RecipeIngredients)
            {
                sumCarbs += ing.Ingredient.Carbohydrates;
            }

            return sumCarbs;
        }

        private double FatsCalc()
        {
            double sumFats = 0;

            foreach (var ing in RecipeIngredients)
            {
                sumFats += ing.Ingredient.Fats;
            }

            return sumFats;
        }


        public string CalculatePriceBar()
        {
            double Price = 0;

            foreach (var ing in RecipeIngredients)
            {
                Price += ing.Ingredient.AveragePrice;
            }

            if (Price < 10) return "Bardzo tanie";
            else if (Price >= 10 && Price < 15) return "Tanie";
            else if (Price >= 15 && Price < 25) return "Œrenio drogie";
            else if (Price >= 25 && Price < 40) return "Drogie";
            else return "Bardzo drogie";
        }

        public List<string> GenerateTags()
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

            tags.Add(PriceBar);
            tags.Add(Difficulty.ToString());

            return tags;
        }
    }
}

