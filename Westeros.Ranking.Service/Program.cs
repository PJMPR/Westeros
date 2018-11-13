using System;
using Westeros.Ranking;
using Westeros.Ranking.Data;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Komentarz k = new Komentarz() {Data = new DateTime(2001, 10, 1), Nick = "OreDa", Tekst = "testowy Koment"};
            Komentarz k2 = new Komentarz() {Data = new DateTime(2001, 12, 21), Nick = "OreJaNai", Tekst = "asdasdasd"};

            Dieta d=new Dieta();

            Console.WriteLine(k.ToString());
            StarkDbContext ctx = new StarkDbContext();
            ctx.Komentarz.Add(k);
            ctx.Komentarz.Add(k2);
            ctx.SaveChanges();
        }
    }
}