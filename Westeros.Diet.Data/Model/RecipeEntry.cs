using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.Data.Model
{
    public class RecipeEntry
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
