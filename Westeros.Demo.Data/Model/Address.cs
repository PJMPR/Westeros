using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Demo.Data.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string LocalNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public Person Owner { get; set; }
    }
}
