using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Demo.Data.Model;

namespace Westeros.Demo.Data.Repositories
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext():base()
        {

        }
        public DemoDbContext(DbContextOptions<DemoDbContext> options) :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DemoDatabase;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
