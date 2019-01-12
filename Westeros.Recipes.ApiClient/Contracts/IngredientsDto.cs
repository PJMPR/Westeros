using System.Collections.Generic;

namespace Westeros.Demo.ApiClient.Contracts
{
    public class IngredientsDto
    {
        public int Id { get; set; } 
        public int IngredientId { get; set; }
        public string Name { get; set; } 
        public enum CategoryType { Vegetable, Fruit, Meat, Fish, Dairy, Delicacies, Other };
        public CategoryType Category { get; set; } 
        public double Proteins { get; set; } 
        public double Fats { get; set; } 
        public double Carbohydrates { get; set; } 
        public double Calories { get; set; } 
        public string PhotoPath { get; set; } 
        public double AvgPrice { get; set; } 
    }
}
