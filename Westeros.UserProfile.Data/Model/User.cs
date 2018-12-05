using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.UserProfile.Data
{

    enum Gender
    {
        Male,
        Female,
        Other
    }

    public class User
    {
        public  int     id          { get; set; }
        private string  name        { get; set; }
        private string  surname     { get; set; }
        private string  login       { get; set; }
        private string  email       { get; set; }
        private int     age         { get; set; }
        private int     weight      { get; set; }
        private Gender  gender      { get; set; }

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
