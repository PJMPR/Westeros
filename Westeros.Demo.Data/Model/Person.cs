using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Demo.Data.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Address> Address { get; set; } = new List<Address>();
    }
}
