using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data
{
    public class Recipe
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<UserRecipe> favouriteRecipes { get; set; }

        public Recipe() { }
    }
}
