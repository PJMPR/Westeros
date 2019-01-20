using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class EntryRecipeDto
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public EntryDto Entry { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}

