using System;
using System.Linq;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

namespace Westeros.Recipes.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var c = new RecipesDbContext())
            {
                //c.Devices.Add(new Device()
                //{
                //    Name = "xD"
                //}
                //);

                //c.savechanges();

                c.Devices.ToList().ForEach(x => Console.WriteLine(x.Name));

            }

        }
    }
}
