using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data
{
    public class UserRecipe
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public User user;

        public int RecipeID { get; set; }
        public Recipe recipe;

    }
}
