using System;

namespace Westeros.Recipes.Data
{

    public class Ingridient {

        public int Id { get; }
        public string Name { get; set; }
        public enum CategoryType {Vegetable, Fruit, Meat, Fish, Dairy, Delicacies, Other};
        public CategoryType Category {get; set;}
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }
        public string PhotoPath { get; set; }
        public double AvgPrice { get; set; }

    }

}
