using System;
using Westeros.Demo.Data.Model;
using Westeros.Demo.Data.Repositories;

namespace Westeros.Demo.Service
{
    class Program
    {
        static void Main(string[] args)
        {

            DemoDbContext ctx = new DemoDbContext();
            var p = new Person
            {
                LastName = "Kowalski",
                Name = "Jan"
            };
            p.Address.Add(new Address
            {
                City="Gdansk",
                HouseNumber="5",
                LocalNumber="12",
                Street="Brzegi"
            });
            ctx.People.Add(p);
            ctx.SaveChanges();
            Console.WriteLine("Hello World!");
        }
    }
}
