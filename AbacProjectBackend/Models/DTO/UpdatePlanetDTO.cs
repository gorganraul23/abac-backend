namespace AbacProjectBackend.Models.DTO
{
    public class UpdatePlanetDTO
    {
        public string? Description { get; set; }
        public int Status { get; set; }
        public Guid? Captain { get; set; }

       
    }
}
