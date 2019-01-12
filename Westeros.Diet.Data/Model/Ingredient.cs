using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Data.Model
{
    public enum CategoryType
    {
        Vegetable,
        Fruit,
        Meat,
        Fish,
        Dairy,
        Delicacies,
        Other
    };

    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public int Calories { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public double Proteins { get; set; }
        public CategoryType Category { get; set; }
        public string Name { get; set; }
        public double AveragePrice { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();
        public ICollection<IngredientEntry> IngredientEntries { get; set; } = new HashSet<IngredientEntry>();
    }
}
