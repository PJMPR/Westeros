using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.ApiClient.Contracts
{
    public class RecipeDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<UserRecipeDto> favouriteRecipes { get; set; }
    }
}
