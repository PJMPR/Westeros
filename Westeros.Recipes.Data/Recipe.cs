using System;


namespace Westeros.Recipes.Data
{
    public class Recipe
    {
        public int Id { get; }
        public string Name { get; set; }
        List<Ingridient> Ingridients = new List<Ingridient>();
        public double SumCalories { get; set; }
        public enum CuisineType { Polish, Italian, Spanish, French, Scandinavian, Hungarian, Arabic, African, Thai, Japanese, Chinese, Russian, American, Other };
        public CuisineType Cuisine { get; set; }
        List<int> Devices = new List<int>();
        public string Description { get; set; }
        public int PrepTime { get; set; } // W minutach
        public enum DifficultyType { Amateur, Easy, Medium, Hard, Masterchef }; // W gwiazdkach
        public DifficultyType Difficulty {get; set;}
        List<string> Tags = new List<string>();
        


        public static int caloriesCalc(List<Ingridient>ingList)
        {
            int sumCalories;

            foreach(Ingridient ing in ingList)
            {
                sumCalories += ing.Calories;
            }

            return sumCalories;
        }

    }

}