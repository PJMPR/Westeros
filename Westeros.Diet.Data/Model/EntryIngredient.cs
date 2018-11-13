using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.Data.Model
{
    public class EntryIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
