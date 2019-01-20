using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class EntryIngredientDto
    {
        public int IngredientId { get; set; }
        public IngredientDto Ingredient { get; set; }
        public int EntryId { get; set; }
        public EntryDto Entry { get; set; }
        public double IngredientQuantity { get; set; }
    }
}
