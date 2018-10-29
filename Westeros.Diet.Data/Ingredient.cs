using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.Data
{
    class Ingredient
    {
        public int Id { get; }
        public string Name { get; }
        public int Calories { get; }
        public double Fats { get; }
        public double Carbs { get; }
        public double Proteins { get;  }
        public string Image { get; }
        public List<string> Tags { get; set; }

        public Ingredient(int id, string name, int calories, double fats, double carbs, double proteins, string image)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Image = image;
            Tags = SetTags();

        }

        //TODO: Zbieranie tagów 
        private List<string> SetTags()
        {
            throw new NotImplementedException();
        }
    }
}
