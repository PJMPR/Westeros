using System;
using System.Collections.Generic;

namespace Westeros.Diet.Data
{
    public class Entry
    {
        public int Id { get; }
        public DateTime Date { get; }
        public double Weight { get; set; }
        private List<IIngredient> ingredients { get; set; }
        public Entry(int id, DateTime date, double weight)
        {
            Id = id;
            Date = date;
            Weight = weight;
            ingredients = new List<IIngredient>();
       
        }
        public Entry(int id, DateTime date, double weight, List<IIngredient> ingredients)
        {
            Id = id;
            Date = date;
            Weight = weight;
            ingredients = ingredients;

        }
    }
}