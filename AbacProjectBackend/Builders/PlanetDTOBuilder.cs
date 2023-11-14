using AbacProjectBackend.Models.DTO;
using AbacProjectBackend.Models;

namespace AbacProjectBackend.Builders
{
    public static class PlanetDTOBuilder
    {
        public static PlanetDTO BuildPlanetDTO(Planet planet)
        {
            return new PlanetDTO
            {
                Id = planet.Id,
                Name = planet.Name,
                Description = planet.Description,
                Status = planet.Status,
                Captain = planet.Captain?.Id,
                ImagePath = planet.ImagePath,
                
            };
        }

        public static PlanetWithTeamDTO BuildPlanetWithCaptainDTO(Planet planet)
        {
            return new PlanetWithTeamDTO
            {
                Id = planet.Id,
                Name = planet.Name,
                Description = planet.Description,
                Status = planet.Status,
                Captain = planet.Captain?.Name,
                ImagePath = planet.ImagePath,
               
            };
        }
    }
}
