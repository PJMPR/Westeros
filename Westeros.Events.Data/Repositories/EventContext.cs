using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Westeros.Events.Data.Model;

namespace Westeros.Events.Data.Repositories

{
  
        public class EventContext : DbContext
        {
            public EventContext(DbContextOptions<EventContext> options) : base(options)
            {

            }
            public EventContext() : base()
            {

            }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EventsDB;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasAlternateKey(u => u.NickName);
            //or: modelBuilder.Entity<User>().HasAlternateKey(u => new { u.Passport, u.Name})
        }
       

            public DbSet<Profile> Profiles { get; set; }
            public DbSet<MailServer> MailServerDb { get; set; }
            public DbSet<IMessage> MailDB { get; set; }
            public DbSet<LogRecord> LogDb { get; set; }
            public DbSet<Recipe> RecipeDb { get; set; }
    }
}



