using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Recipes.Data.Model
{
    public class RecipeIngridient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngridientId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingridient Ingridient { get; set; }
    }
}
