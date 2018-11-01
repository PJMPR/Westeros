﻿using System;
using Westeros.Ranking;
using Westeros.Ranking.Data;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Komentarz k=new Komentarz("OreDa", "to jest komentarz", new DateTime(2000, 12, 12));

            Console.WriteLine(k.ToString());
            KomentarzeDbContext ctx=new KomentarzeDbContext();
            ctx.Komentarz.Add(k);
            ctx.SaveChanges();
            Console.Read();
        }
    }
}