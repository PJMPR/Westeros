using System;
using Westeros.Diet.Data.Model;
using Westeros.Diet.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Westeros.Diet.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DietDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Hello World!");
                Console.ReadKey();
            }
        }
    }
}
