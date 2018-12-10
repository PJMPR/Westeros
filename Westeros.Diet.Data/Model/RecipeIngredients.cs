using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.Data.Model
{
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }  
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
