namespace AbacProjectBackend.Models.DTO
{
    public class PlanetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public PlanetStatus Status { get; set; }

        public Guid? Captain { get; set; }

        public string ImagePath { get; set; }

     
    }
}
