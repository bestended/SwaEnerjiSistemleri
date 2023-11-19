using Microsoft.EntityFrameworkCore;

namespace SwaEnerjiSistemleri.Models
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            

        }

        public DbSet<Dagiticilar>? Dagiticilars { get; set; }
        public DbSet<Firmalar>? Firmalars { get; set; }
        public DbSet<Sehirler>? Sehirlers { get; set; }
        public DbSet<Tuketiciler>? Tuketicilers { get; set; }




    }
}
