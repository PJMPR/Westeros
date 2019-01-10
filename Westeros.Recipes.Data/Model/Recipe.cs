using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Westeros.Recipes.Data.Model;

namespace Westeros.Recipes.Data
{
    public enum DifficultyType { Amateur, Easy, Medium, Hard, Masterchef };
    public enum CuisineType { Polish, Italian, Spanish, French, Scandinavian, Hungarian, Arabic, African, Thai, Japanese, Chinese, Russian, American, Other };

    public class Recipe
    {
        public int Id { get; set; } // Id przepisu
        public string Name { get; set; } // Nazwa przepisu
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>(); // Lista (kolekcja) sk³adników

        [NotMapped]
        public double Calories => CaloriesCalc();
        [NotMapped] public double Proteins => ProteinsCalc();
        [NotMapped] public double Carbohydrates => CarbsCalc();
        [NotMapped] public double Fats => FatsCalc();
        public Boolean IsNew { get; set; } = true;
        
        public CuisineType Cuisine { get; set; } // Typ kuchni w³oska, azjatycka itp
        public ICollection<RecipeDevice> RecipeDevices { get; set; } = new HashSet<RecipeDevice>(); // Przyrz¹dy które potrzebujemy: piekarnik, blender itp.
        public string Description { get; set; } // Opis przepisu
        public int PrepTime { get; set; } // Czas przygotowania w minutach
        public DifficultyType Difficulty { get; set; } // Poziom trudnoœci [1-5]
        [NotMapped]
        public string PriceBar => CalculatePriceBar(); // Czy danie jest tanie/drogie
        public string PhotoPath { get; set; } // Œcie¿ka do zdjêcia przepisu
        [NotMapped] public List<string> Tag => GenerateTags();
   

        public Recipe NewInstance()
        {
            return new Recipe();
        }


        private double CaloriesCalc()
        {
            // Kalkulator kalorii - liczy sumê kalorii wszystkich sk³adników
            double sumCalories = 0;

            foreach(var ing in RecipeIngredients)
            {
                sumCalories += ing.Ingredient.Calories;
            }

            return sumCalories;
        }
   
        private double ProteinsCalc()
        {
            // Kalkulator bia³ek - liczy sumê bia³ek wszystkich sk³adników
            double sumProteins = 0;

            foreach (var ing in RecipeIngredients)
            {
                sumProteins += ing.Ingredient.Proteins;
            }

            return sumProteins;
        }

        private double CarbsCalc()
        {
            // Kalkulator wêglowodanów - liczy sumê wêglowodanów wszystkich sk³adników
            double sumCarbs = 0;

            foreach (var ing in RecipeIngredients)
            {
                sumCarbs += ing.Ingredient.Carbohydrates;
            }

            return sumCarbs;
        }

        private double FatsCalc()
        {
            // Kalkulator t³uszczy - liczy sumê t³uszczy wszystkich sk³adników
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
            List<string> tags = new List<string>();

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

