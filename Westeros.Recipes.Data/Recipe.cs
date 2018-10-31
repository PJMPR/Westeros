using System;
using System.Collections.Generic;

namespace Westeros.Recipes.Data
{
    public class Recipe
    {
        public int Id { get; } // Id przepisu
        public string Name { get; set; } // Nazwa przepisu
        private readonly List<Ingridient> ingridients; // Lista (kolekcja) sk�adnik�w

        public double Calories { get; private set; } // Suma kalorii wszystkich sk�adnik�w
        public double Proteins { get; private set; } // Suma bia�ek
        public double Carbohydrates { get; private set; } // Suma w�glowodan�w
        public double Fats { get; private set; } // Suma wszystkich t�uszczy

        public enum CuisineType { Polish, Italian, Spanish, French, Scandinavian, Hungarian, Arabic, African, Thai, Japanese, Chinese, Russian, American, Other };
        public CuisineType Cuisine { get; set; } // Typ kuchni w�oska, azjatycka itp
        private List<string> devices = new List<string>(); // Przyrz�dy kt�re potrzebujemy: piekarnik, blender itp.
        public string Description { get; set; } // Opis przepisu
        public int PrepTime { get; set; } // Czas przygotowania w minutach
        public enum DifficultyType { Amateur, Easy, Medium, Hard, Masterchef }; 
        public DifficultyType Difficulty {get; set; } // Poziom trudno�ci [1-5]

        public string PriceBar { get; set; } // Czy danie jest tanie/drogie
        public string PhotoPath { get; set; } // �cie�ka do zdj�cia przepisu
        private List<string> tags = new List<string>(); // Lista tag�w

        public Recipe(int id, string name, CuisineType cuisine, List<string> devices, string description, int prepTime, DifficultyType difficulty, string photoPath, string priceBar,List<Ingridient> ingridients=null)
        {

            Id = id;
            Name = name;
            this.ingridients = ingridients ?? new List<Ingridient>();
            Cuisine = cuisine;
            this.devices = devices;
            Description = description;
            PrepTime = prepTime;
            Difficulty = difficulty;
            PhotoPath = photoPath;
            PriceBar = priceBar;

            CalculateMakros(this.ingridients);
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

            foreach (Ingridient ing in ingridients)
            {
                tags.Add(ing.Name);
            }

            foreach (string dev in devices)
            {
                tags.Add(dev);
            }

            tags.Add(Cuisine.ToString());
            tags.Add(Difficulty.ToString());
            tags.Add(PriceBar);
        }
        
    }

}
