using Microsoft.EntityFrameworkCore;

namespace Westeros.Ranking.Data.Repositories
{
    public class StarkDbContext : DbContext
    {
        public StarkDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StarkBazaDanych;Integrated Security=True;");
        }

        public DbSet<Komentarz> Komentarz { get; set; }
        public DbSet<Przepis> PrzepisyOdwiedziny { get; set; }
        public DbSet<Dieta> DietyOdwiedziny { get; set; }
    }
}