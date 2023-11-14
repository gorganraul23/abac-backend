using Azure;

namespace AbacProjectBackend.Models
{
    public class Planet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public PlanetStatus Status { get; set; }

        public Explorer? Captain { get; set; }

        public string ImagePath { get; set; }

        //public List<Explorer> Robots { get; } = new();

    }
}
