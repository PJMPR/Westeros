using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Westeros.Diet.Data.Model
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        //private ICollection<IIngredient> _ingredients ;
        public ICollection<EntryRecipe> EntryRecipes { get; set; }
        public ICollection<EntryIngredient> EntryIngredients { get; set; }




    }
}