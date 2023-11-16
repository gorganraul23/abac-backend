namespace AbacProjectBackend.Models
{
    public class PlanetExplorer
    {
        public Guid PlanetId { get; set; }
        public Planet Planet { get; set; }
        public Guid ExplorerId { get; set; }
        public Explorer Explorer { get; set; }
    }
}
