using System.Collections.Generic;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public double Proteins { get; set; }
        public CategoryType Category { get; set; }
        public string Name { get; set; }
        public double AveragePrice { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<RecipeIngredientDto> RecipeIngredients { get; set; } = new List<RecipeIngredientDto>();
        public ICollection<EntryIngredientDto> EntryIngredients { get; set; } = new List<EntryIngredientDto>();
    }
}
