using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data
{

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class User
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

        public ICollection<UserRecipe> favouriteRecipes { get; set; }

        public User()
        {

        }

        public User(string login, string email, string name = "Nie podano", string surname = "Nie podano", Nullable<int> age = null, Nullable<decimal> weight = null, Nullable<decimal> height = null, string gender = null)
        {
            this.login = login;
            this.email = email;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.weight = weight;
            this.height = height;

            if (gender == "Male")
                this.gender = Gender.Male;
            else if (gender == "Female")
                this.gender = Gender.Female;
            else
                this.gender = Gender.Other;
        }
    }
}
