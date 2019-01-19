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
        public int age { get; set; }
        public int weight { get; set; }
        public Gender gender { get; set; }

        public ICollection<UserRecipe> favouriteRecipes { get; set; }

        public User()
        {

        }

        public User(string login, string email)
        {
            this.login = login;
            this.email = email;
        }

        public User(string name, string surname, string login, string email, int age, int weight, string gender)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.email = email;
            this.age = age;
            this.weight = weight;

            if (gender == "Male")
                this.gender = Gender.Male;
            else if (gender == "Female")
                this.gender = Gender.Female;
            else
                this.gender = Gender.Other;
        }
    }
}
