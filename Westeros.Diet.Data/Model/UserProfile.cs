using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Options;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Data.Model
{
    public enum Sex
    {
        Male,
        Female
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public ICollection<Entry> Entries { get; set; } = new List<Entry>();
    }
}
