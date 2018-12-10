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
        public int      id      { get; set; }
        public string   name    { get; set; }
        public string   surname { get; set; }
        public string   login   { get; set; }
        public string   email   { get; set; }
        public int      age     { get; set; }
        public decimal  weight  { get; set; }
        public decimal  height  { get; set; }
        public Gender   gender  { get; set; }

        public User() { }

        public User(string login, string email)
        {
            this.login = login;
            this.email = email;
        }
    }
}
