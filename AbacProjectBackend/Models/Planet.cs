
namespace AbacProjectBackend.Models
{
    public class Planet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public PlanetStatus Status { get; set; }

        public string ImagePath { get; set; }

        public ICollection<PlanetExplorer> PlanetExplorers { get; set; }

    }
}
