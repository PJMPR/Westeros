using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Westeros.Recipes.Data.Model;

namespace Westeros.Recipes.Data
{
    public class Recipe
    {
        public int Id { get; set; } // Id przepisu
        public string Name { get; set; } // Nazwa przepisu
        public ICollection<Ingridient> Ingridients { get; set; } // Lista (kolekcja) sk�adnik�w

        public double Calories { get; private set; } // Suma kalorii wszystkich sk�adnik�w
        public double Proteins { get; private set; } // Suma bia�ek
        public double Carbohydrates { get; private set; } // Suma w�glowodan�w
        public double Fats { get; private set; } // Suma wszystkich t�uszczy

        public enum CuisineType { Polish, Italian, Spanish, French, Scandinavian, Hungarian, Arabic, African, Thai, Japanese, Chinese, Russian, American, Other };
        public CuisineType Cuisine { get; set; } // Typ kuchni w�oska, azjatycka itp

        public ICollection<Device> Devices { get; set;} // Przyrz�dy kt�re potrzebujemy: piekarnik, blender itp.
        public string Description { get; set; } // Opis przepisu
        public int PrepTime { get; set; } // Czas przygotowania w minutach
        public enum DifficultyType { Amateur, Easy, Medium, Hard, Masterchef }; 
        public DifficultyType Difficulty {get; set; } // Poziom trudno�ci [1-5]

        public string PriceBar { get; set; } // Czy danie jest tanie/drogie
        public string PhotoPath { get; set; } // �cie�ka do zdj�cia przepisu
        [NotMapped]
        private List<string> tags = new List<string>(); // Lista tag�w

        public Recipe(string name, CuisineType cuisine, string description, int prepTime, DifficultyType difficulty, string photoPath, string priceBar)
        {
            Name = name;
//            this.ingridients = ingridients;
            Cuisine = cuisine;
      //      this.devices = devices;
            Description = description;
            PrepTime = prepTime;
            Difficulty = difficulty;
            PhotoPath = photoPath;
            PriceBar = priceBar;

           //CalculateMakros(this.ingridients);
            GenerateTags();

        }

        public static double CaloriesCalc(List<Ingridient>ingList)
        {
            // Kalkulator kalorii - liczy sum� kalorii wszystkich sk�adnik�w
            double sumCalories = 0;

            foreach(Ingridient ing in ingList)
            {
                sumCalories += ing.Calories;
            }

            return sumCalories;
        }
   
        public static double ProteinsCalc(List<Ingridient> ingList)
        {
            // Kalkulator bia�ek - liczy sum� bia�ek wszystkich sk�adnik�w
            double sumProteins = 0;

            foreach (Ingridient ing in ingList)
            {
                sumProteins += ing.Proteins;
            }

            return sumProteins;
        }

        public static double CarbsCalc(List<Ingridient> ingList)
        {
            // Kalkulator w�glowodan�w - liczy sum� w�glowodan�w wszystkich sk�adnik�w
            double sumCarbs = 0;

            foreach (Ingridient ing in ingList)
            {
                sumCarbs += ing.Carbohydrates;
            }

            return sumCarbs;
        }

        public static double FatsCalc(List<Ingridient> ingList)
        {
            // Kalkulator t�uszczy - liczy sum� t�uszczy wszystkich sk�adnik�w
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

        public string CalculatePriceBar(List<Ingridient> ingList) {

            double Price = 0;

            foreach (Ingridient ing in ingList)
            {
                Price += ing.AvgPrice;
            }

            if (Price < 10) return "Bardzo tani";
            else if (Price >= 10 && Price < 15) return "Tani";
            else if (Price >= 15 && Price < 25) return "�reni";
            else if (Price >= 25 && Price < 40) return "Drogi";
            else return "Bardzo drogi";
      
        }

        public void GenerateTags() {

            foreach (Ingridient ing in Ingridients)
            {
                tags.Add(ing.Name);
            }

            foreach (var dev in Devices)
            {
                tags.Add(dev.Name);
            }

            tags.Add(Cuisine.ToString());
            tags.Add(Difficulty.ToString());
            tags.Add(PriceBar);
        }
        
    }

}
