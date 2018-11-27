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

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
