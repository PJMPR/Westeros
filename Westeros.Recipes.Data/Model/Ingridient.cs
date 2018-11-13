using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Westeros.Recipes.Data
{

    public class Ingridient {
        [Key]
        public int Id { get; set; } // Id składnika
        public string Name { get; set; } // Nazwa składnika
        public enum CategoryType {Vegetable, Fruit, Meat, Fish, Dairy, Delicacies, Other};
        public CategoryType Category {get; set;} // Typ składnika: mięso, warzywa itp.
        public double Proteins { get; set; } // Białka
        public double Fats { get; set; } // Tłuszcze
        public double Carbohydrates { get; set; } // Węglowodany (cukry)
        public double Calories { get; set; } // Kalorie
        public string PhotoPath { get; set; } // Ścieżka do zdjęcia składnika
        public double AvgPrice { get; set; } // Średnia cena

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
