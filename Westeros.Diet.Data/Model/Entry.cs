﻿using System;
using System.Collections.Generic;

namespace Westeros.Diet.Data.Model
{
    public class Entry
    {
        public int Id { get; }
        public DateTime Date { get; }
        public double Weight { get; set; }
        private List<IIngredient> _ingredients;
        
        public Entry(int id, DateTime date, double weight, List<IIngredient> ingredients=null)
        {
            Id = id;
            Date = date;
            Weight = weight;
            _ingredients = ingredients ?? new List<IIngredient>();

        }
    }
}