﻿using Microsoft.EntityFrameworkCore;
using Westeros.Ranking.Data.Model;

namespace Westeros.Ranking.Data.Repositories
{
    public class StarkDbContext : DbContext
    {

        public StarkDbContext(DbContextOptions<StarkDbContext>o) : base()
        {
        }

        public StarkDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StarkBazaDanych;Integrated Security=True;");
        }

        public DbSet<Oceny> Oceny { get; set; }
        public DbSet<Przepis> PrzepisyOdwiedziny { get; set; }
        public DbSet<Dieta> DietyOdwiedziny { get; set; }
    }
}