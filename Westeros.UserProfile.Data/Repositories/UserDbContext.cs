using Microsoft.EntityFrameworkCore;

namespace Westeros.UserProfile.Data.Repositories
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> o) : base()
        {

        }

        public UserDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TargeryanUser;Integrated Security=True;");
        }
        public DbSet<User> User { get; set; }
        
    }
}
