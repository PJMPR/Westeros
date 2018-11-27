using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Westeros.Demo.Data.Model
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Address> Address { get; set; } = new List<Address>();
    }
}
