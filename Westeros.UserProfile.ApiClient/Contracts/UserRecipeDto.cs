using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.ApiClient.Contracts
{
    public class UserRecipeDto
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public UserDto user;

        public int RecipeID { get; set; }
        public RecipeDto recipe;
    }
}
