using Microsoft.EntityFrameworkCore;

namespace Westeros.Ranking.Data.Repositories
{
    public class KomentarzeDbContext:DbContext
    {
        public KomentarzeDbContext():base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StarkKomentarze;Integrated Security=True;");
        }

        public DbSet<Komentarz> Komentarz { get; set; }

    }
}
