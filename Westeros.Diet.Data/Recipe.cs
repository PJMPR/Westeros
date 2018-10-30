using System;
using System.Collections.Generic;
using System.Linq;

namespace Westeros.Diet.Data
{
    public class Recipe : IIngredient
    {
        public int Id { get; }
        public string Name { get; private set; }
        public int Calories { get; private set; }
        public double Fats { get; private set; }
        public double Carbs { get; private set; }
        public double Proteins { get; private set; }
        public string Image { get; }
        private List<string> _tags;
        private List<Ingredient> _ingredients; 

        public Recipe(int id, string name, string image, List<Ingredient> ingredients = null)
        {
            Id = id;
            Name = name;
            Calories = ingredients.Sum(x => x.Calories);
            Fats = ingredients.Sum(x => x.Fats);
            Carbs = ingredients.Sum(x => x.Carbs);
            Proteins = ingredients.Sum(x => x.Proteins);
            Image = image;
            _tags = SetTags();
            _ingredients = ingredients ?? new List<Ingredient>();
        }

        private List<string> SetTags()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTags()
        {
            return _tags.ToList();    
        }

        public List<Ingredient> GetAllingredients()
        {
            return _ingredients.ToList();
        }

        public void AddIngredient(int id)
        {
            var ing = Ingredient.GetIngredient(id);
            _ingredients.Add(ing);
            CalculateMacros();
        }

        private void CalculateMacros()
        {
            Calories = _ingredients.Sum(x => x.Calories);
            Fats = _ingredients.Sum(x => x.Fats);
            Carbs = _ingredients.Sum(x => x.Carbs);
            Proteins = _ingredients.Sum(x => x.Proteins);
        }
    }
}
