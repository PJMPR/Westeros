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
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CategoryType Category { get; private set; }
        public int Calories { get; private set; }
        public decimal Fats { get; private set; }
        public decimal Carbohydrates { get; private set; }
        public decimal Proteins { get; private set; }
        public string Image { get; private set; }
        public decimal AveragePrice { get; private set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
        public ICollection<EntryRecipe> EntryRecipes { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Category} {Calories} {Fats} {Carbohydrates} {Proteins} {Image} {AveragePrice}";
        }
    }
}
