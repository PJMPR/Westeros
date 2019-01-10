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
        public ICollection<RecipeIngridient> RecipeIngredients { get; set; } = new HashSet<RecipeIngridient>(); // Lista (kolekcja) sk³adników

        public double Calories { get; private set; } // Suma kalorii wszystkich sk³adników
        public double Proteins { get; private set; } // Suma bia³ek
        public double Carbohydrates { get; private set; } // Suma wêglowodanów
        public double Fats { get; private set; } // Suma wszystkich t³uszczy
        public Boolean IsNew { get; set; } = true;
        
        public CuisineType Cuisine { get; set; } // Typ kuchni w³oska, azjatycka itp
        public ICollection<RecipeDevice> RecipeDevices { get; set; } = new HashSet<RecipeDevice>(); // Przyrz¹dy które potrzebujemy: piekarnik, blender itp.
        public string Description { get; set; } // Opis przepisu
        public int PrepTime { get; set; } // Czas przygotowania w minutach
        public DifficultyType Difficulty { get; set; } // Poziom trudnoœci [1-5]
        public string PriceBar { get; set; } // Czy danie jest tanie/drogie
        public string PhotoPath { get; set; } // Œcie¿ka do zdjêcia przepisu
        [NotMapped]
        private List<string> _tags;
        [NotMapped]
        public List<string> Tag
        {
            get { return _tags ?? (_tags = GenerateTags()); }
        }

        public Recipe NewInstance()
        {
            return new Recipe();
        }
       

        public static double CaloriesCalc(List<Ingridient>ingList)
        {
            // Kalkulator kalorii - liczy sumê kalorii wszystkich sk³adników
            double sumCalories = 0;

            foreach(Ingridient ing in ingList)
            {
                sumCalories += ing.Calories;
            }

            return sumCalories;
        }
   
        public static double ProteinsCalc(List<Ingridient> ingList)
        {
            // Kalkulator bia³ek - liczy sumê bia³ek wszystkich sk³adników
            double sumProteins = 0;

            foreach (Ingridient ing in ingList)
            {
                sumProteins += ing.Proteins;
            }

            return sumProteins;
        }

        public static double CarbsCalc(List<Ingridient> ingList)
        {
            // Kalkulator wêglowodanów - liczy sumê wêglowodanów wszystkich sk³adników
            double sumCarbs = 0;

            foreach (Ingridient ing in ingList)
            {
                sumCarbs += ing.Carbohydrates;
            }

            return sumCarbs;
        }

        public static double FatsCalc(List<Ingridient> ingList)
        {
            // Kalkulator t³uszczy - liczy sumê t³uszczy wszystkich sk³adników
            double sumFats = 0;

            foreach (Ingridient ing in ingList)
            {
                sumFats += ing.Fats;
            }

            return sumFats;
        }

        public void CalculateMakros(List<Ingridient> ingList)
        {
            Calories = CaloriesCalc(ingList);
            Proteins = ProteinsCalc(ingList);
            Fats = FatsCalc(ingList);
            Carbohydrates = CarbsCalc(ingList);
        }

        public string CalculatePriceBar(IEnumerable<Ingridient> ingList) 
        {
            double Price = 0;

            foreach (Ingridient ing in ingList)
            {
                Price += ing.AvgPrice;
            }

            if (Price < 10) return "Bardzo tanie";
            else if (Price >= 10 && Price < 15) return "Tanie";
            else if (Price >= 15 && Price < 25) return "Œrenio drogie";
            else if (Price >= 25 && Price < 40) return "Drogie";
            else return "Bardzo drogie";
      
        }


        public List<string> GenerateTags()
        {
            List<string> tagi = new List<string>();

            foreach (var ing in RecipeIngredients)
            {
                tagi.Add(ing.Ingridient.Name);
            }

            foreach (var dev in RecipeDevices)
            {
                tagi.Add(dev.Device.Name);
            }

            var Ingredients = RecipeIngredients.Select(i => i.Ingridient);
            tagi.Add(CalculatePriceBar(Ingredients));

            tagi.Add(Difficulty.ToString());
            return tagi;

        }
    }
}

