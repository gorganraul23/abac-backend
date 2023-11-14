using AbacProjectBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace AbacProjectBackend.Data
{
    public class PlanetDbContext: DbContext
    {
        public PlanetDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Explorer> Explorers { get; set; }

    }
}
