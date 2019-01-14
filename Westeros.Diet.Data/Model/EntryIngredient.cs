using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Westeros.Diet.Data.Model
{
    public class EntryIngredient
    {
        [Key]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        [Key]
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
        [Required]
        public double IngredientQuantity { get; set; }

    }
}
