using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class RecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public IngredientDto Ingredient { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
        public double IngredientQuantity { get; set; }
    }
}
