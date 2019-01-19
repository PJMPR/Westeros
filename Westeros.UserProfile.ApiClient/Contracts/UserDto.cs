using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.ApiClient.Contracts
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<Gender> gender { get; set; }

        public ICollection<UserRecipeDto> favouriteRecipes { get; set; }

    }
}