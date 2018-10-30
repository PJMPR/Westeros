using System;
using System.Collections.Generic;
using System.Linq;

namespace Westeros.Diet.Data
{
    public class Ingredient : IIngredient
    {
        public int Id { get; }
        public string Name { get; }
        public int Calories { get; }
        public double Fats { get; }
        public double Carbs { get; }
        public double Proteins { get; }
        public string Image { get; }
        private readonly List<string> _tags;

        public Ingredient(int id, string name, int calories, double fats, double carbs, double proteins, string image)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Image = image;
            _tags = SetTags();
        }

        //TODO: Zbieranie tagów 
        private List<string> SetTags()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTags()
        {
            return _tags.ToList();
        }

        public static Ingredient GetIngredient(int id)
        {
            //TODO: zwraca składnik z bazy po ID 
            throw new NotImplementedException();
        }

        public static List<Ingredient> GetAllIngredients()
        {
            //TODO: zwraca składnik z bazy po ID 
            throw new NotImplementedException();
        }
    }
}
