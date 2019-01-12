using System;
using System.Collections.Generic;

using Westeros.Recipes.Data;
using Westeros.Recipes.Data.Model;

namespace Westeros.Demo.ApiClient.Contracts
{

    public enum DifficultyType { Amateur, Easy, Medium, Hard, Masterchef };
    public enum CuisineType { Polish, Italian, Spanish, French, Scandinavian, Hungarian, Arabic, African, Thai, Japanese, Chinese, Russian, American, Other };
    public class RecipesDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public ICollection<RecipeIngredient> Ingredients { get; set; } = new HashSet<RecipeIngredient>();

        public double Calories { get; private set; } 
        public double Proteins { get; private set; } 
        public double Carbohydrates { get; private set; } 
        public double Fats { get; private set; } 
        public Boolean IsNew { get; set; } = true;

        public CuisineType Cuisine { get; set; } 
        public ICollection<Device> Devices { get; set; } = new HashSet<Device>(); 
        public string Description { get; set; } 
        public int PrepTime { get; set; } 
        public DifficultyType Difficulty { get; set; } 
        public string PriceBar { get; set; } 
        public string PhotoPath { get; set; } 
    }
}
