﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Westeros.Diet.Data.Model
{
    public class RecipeIngredient
    {
        [Key]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        [Key]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        [Required]
        public double IngredientQuantity { get; set; }
    }
}
