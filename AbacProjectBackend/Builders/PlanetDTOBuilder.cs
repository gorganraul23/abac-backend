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
                ImagePath = planet.ImagePath,
                
            };
        }

        public static PlanetWithExplorersDTO BuildPlanetWithExplorersNameDTO(Planet planet)
        {
            var robots = planet.PlanetExplorers
                .Where(pe => pe.Explorer.Type == ExplorerType.Robot)
                .Select(pe => pe.Explorer.Name)
                .ToList();
            var captain = planet.PlanetExplorers
                .FirstOrDefault(pe => pe.Explorer.Type == ExplorerType.Captain)?.Explorer.Name;

            return new PlanetWithExplorersDTO
            {
                Id = planet.Id,
                Name = planet.Name,
                Description = planet.Description,
                Status = planet.Status,
                ImagePath = planet.ImagePath,
                Captain = captain,
                Robots = robots
            };
        }

        public static PlanetWithExplorersDTO BuildPlanetWithExplorersIdDTO(Planet planet)
        {
            var robots = planet.PlanetExplorers
                .Where(pe => pe.Explorer.Type == ExplorerType.Robot)
                .Select(pe => pe.Explorer.Id.ToString())
                .ToList();
            var captain = planet.PlanetExplorers
                .FirstOrDefault(pe => pe.Explorer.Type == ExplorerType.Captain)?.Explorer.Id.ToString();

            return new PlanetWithExplorersDTO
            {
                Id = planet.Id,
                Name = planet.Name,
                Description = planet.Description,
                Status = planet.Status,
                ImagePath = planet.ImagePath,
                Captain = captain,
                Robots = robots
            };
        }
    }
}
