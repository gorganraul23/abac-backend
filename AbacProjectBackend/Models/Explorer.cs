using Azure;

namespace AbacProjectBackend.Models
{
    public class Explorer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ExplorerType Type { get; set; }

        //public List<Planet> Planets { get; } = new();
    }
}
