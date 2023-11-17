using AbacProjectBackend.Configuration;
using AbacProjectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AbacProjectBackend.Data
{
    public class PlanetDbContext: DbContext
    {
        public PlanetDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Explorer> Explorers { get; set; }

        public DbSet<PlanetExplorer> PlanetExplorers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanetExplorer>()
                .HasKey(bc => new { bc.PlanetId, bc.ExplorerId });
            modelBuilder.Entity<PlanetExplorer>()
                .HasOne(bc => bc.Planet)
                .WithMany(b => b.PlanetExplorers)
                .HasForeignKey(bc => bc.PlanetId);
            modelBuilder.Entity<PlanetExplorer>()
                .HasOne(bc => bc.Explorer)
                .WithMany(c => c.PlanetExplorers)
                .HasForeignKey(bc => bc.ExplorerId);

            // populate database
            modelBuilder.ApplyConfiguration(new PlanetConfiguration());
            modelBuilder.ApplyConfiguration(new ExplorerConfiguration());
        }

    }
}
