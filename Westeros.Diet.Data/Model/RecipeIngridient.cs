using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Data.Model
{
    public class RecipeIngridient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngridientId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
