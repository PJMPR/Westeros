using System;
using Westeros.Ranking;
using Westeros.Ranking.Data;

namespace Westeros.Ranking.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Komentarz k=new Komentarz("OreDa", "to jest komentarz", new DateTime(2000, 12, 12));

            //Console.WriteLine("Hello World!");
            Console.WriteLine(k.ToString());
            Console.Read();
        }
    }
}
