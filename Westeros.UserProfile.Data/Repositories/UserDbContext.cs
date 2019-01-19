using Microsoft.EntityFrameworkCore;
namespace Westeros.UserProfile.Data.Repositories
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<UserRecipe> UserRecipe { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> o) : base()
        {

        }

        public UserDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TargeryanUser;Integrated Security=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(m => m.name).IsRequired(false);
            modelBuilder.Entity<User>().Property(m => m.surname).IsRequired(false);
            modelBuilder.Entity<User>().Property(m => m.email).IsRequired(true);
            base.OnModelCreating(modelBuilder);
        }

    }


}
