using System;
using System.Collections.Generic;
using System.Linq;

namespace Westeros.Diet.Data
{
    class Recipe : IIngredient
    {
        public int Id { get; }
        public string Name { get; }
        public int Calories { get; }
        public double Fats { get; }
        public double Carbs { get; }
        public double Proteins { get; }
        public string Image { get; }
        public List<string> Tags { get; set; }
        public List<Ingredient> Ingredients { get; }

        public Recipe(int id, string name, string image, List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            Calories = ingredients.Sum(x => x.Calories);
            Fats = ingredients.Sum(x => x.Fats);
            Carbs = ingredients.Sum(x => x.Carbs);
            Proteins = ingredients.Sum(x => x.Proteins);
            Image = image;
            Tags = SetTags();
            Ingredients = ingredients;
        }

        private List<string> SetTags()
        {
            throw new NotImplementedException();
        }
    }
}
