using System;
using System.Collections.Generic;
using System.Linq;

namespace Westeros.Diet.Data
{
    public enum Gender { Male, Female, Other}

    public class UserProfile
    {
        public int Id { get; set; }
        public Gender Sex { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        private List<Entry> _dairy;

        public List<Entry> GetAllEntries()
        {
            return _dairy.ToList();
        }

        public void AddEntry(Entry entry)
        {
            _dairy.Add(entry);
        }

        public UserProfile(int id, Gender sex, int age, double weight, double height)
        {
            Id = id;
            Sex = sex;
            Age = age;
            Weight = weight;
            Height = height;
            _dairy = new List<Entry>();

        }
    }
}
