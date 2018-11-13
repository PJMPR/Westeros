using System;
using System.Linq;
using Westeros.Recipes.Data;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

namespace Westeros.Recipes.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var c = new RecipesDbContext())
            {
                c.Devices.Add(new Device()
                {
                    Name = "Piekarnik"
                }
                );
                c.Devices.Add(new Device()
                {
                    Name = "Blender"
                }
                );
                c.Devices.Add(new Device()
                {
                    Name = "Mikser"
                }
                );
                
                c.SaveChanges();

                var Przepis = new Recipe {
                    Name = "Spaghetti Bolognese"
                };
                var Ingridient1 = new Ingridient
                {
                    Name = "Makaron",
                    AvgPrice = 6
                };
                var Ingridient2 = new Ingridient
                {
                    Name = "Pomidory",
                    AvgPrice = 8
                };
                var Ingridient3 = new Ingridient
                {
                    Name = "Mieso",
                    AvgPrice = 14
                };


                Przepis.Ingridients.Add(Ingridient1);
                Przepis.Ingridients.Add(Ingridient2);
                Przepis.Ingridients.Add(Ingridient3);
           
                Przepis.Difficulty = DifficultyType.Easy;
                Przepis.Cuisine = CuisineType.Italian;

                Console.WriteLine("Lista tagów:");
                var i = 0;

                foreach (var item in Przepis.Tag)
                {
                    i++;
                    Console.WriteLine("[" + i + "] " + item);
                }               
                



                //c.Devices.ToList().ForEach(x => Console.WriteLine(x.Name));

            }

        }
    }
}
