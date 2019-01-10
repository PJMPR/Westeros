using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Westeros.Recipes.Data.Model;

namespace Westeros.Recipes.Data
{
    public enum CategoryType { Vegetable, Fruit, Meat, Fish, Dairy, Delicacies, Other };
    public class Ingredient {
        [Key]
        public int Id { get; set; } // Id składnika
        public string Name { get; set; } // Nazwa składnika
        public CategoryType Category {get; set;} // Typ składnika: mięso, warzywa itp.
        public double Proteins { get; set; } // Białka
        public double Fats { get; set; } // Tłuszcze
        public double Carbohydrates { get; set; } // Węglowodany (cukry)
        public int Calories { get; set; } // Kalorie
        public string PhotoPath { get; set; } // Ścieżka do zdjęcia składnika
        public double AveragePrice { get; set; } // Średnia cena
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();


    }

}
