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
        public ICollection<IngredientEntry> EntryIngredients { get; set; } = new List<IngredientEntry>();
        public ICollection<RecipeEntry> EntryRecipes { get; set; } = new List<RecipeEntry>();
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}