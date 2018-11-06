using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Westeros.Events.Data.Model;

namespace Westeros.Events.Data.Repositories

{
  
        public class EventContext : DbContext
        {
            public EventContext() : base()
            {

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EventsDB;Integrated Security=True;");
            }

            public DbSet<Profile> Profiles { get; set; }
            public DbSet<Message> MailDB { get; set; }
            public DbSet<LogRecord> LogDb { get; set; }
    }
}



