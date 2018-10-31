using System;
using System.Collections.Generic;

namespace Westeros.Recipes.Data
{

    public class Ingridient {
        
        public int Id { get; } // Id składnika
        public string Name { get; set; } // Nazwa składnika
        public enum CategoryType {Vegetable, Fruit, Meat, Fish, Dairy, Delicacies, Other};
        public CategoryType Category {get; set;} // Typ składnika: mięso, warzywa itp.
        public double Proteins { get; set; } // Białka
        public double Fats { get; set; } // Tłuszcze
        public double Carbohydrates { get; set; } // Węglowodany (cukry)
        public double Calories { get; set; } // Kalorie
        public string PhotoPath { get; set; } // Ścieżka do zdjęcia składnika
        public double AvgPrice { get; set; } // Średnia cena

        public Ingridient(int id, string name, CategoryType category, double proteins, double fats, double carbohydrates, double calories, string photoPath, double avgPrice)
        {
            Id = id;
            Name = name;
            Category = category;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Calories = calories;
            PhotoPath = photoPath;
            AvgPrice = avgPrice;
        }

        public static Ingridient GetIngridient(int id)
        {
            throw new NotImplementedException();
        }

        public static List<Ingridient> GetAllIngridients()
        {
            throw new NotImplementedException();
        }

    }

}
