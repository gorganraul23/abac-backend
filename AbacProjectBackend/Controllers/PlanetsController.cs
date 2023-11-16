using AbacProjectBackend.Builders;
using AbacProjectBackend.Data;
using AbacProjectBackend.Models;
using AbacProjectBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbacProjectBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlanetsController : Controller
    {
        private readonly PlanetDbContext _planetDbContext;

        public PlanetsController(PlanetDbContext planetDbContext)
        {
            this._planetDbContext = planetDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanets()
        {
            var planets = await _planetDbContext.Planets
                .Include(pe => pe.PlanetExplorers)
                .ThenInclude(e => e.Explorer)
                .ToListAsync();

            var planetsDTO = planets.Select(planet => PlanetDTOBuilder.BuildPlanetWithExplorersNameDTO(planet));
            return Ok(planetsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetPlanet(Guid id)
        {
            var planet = await _planetDbContext.Planets
                .Include(pe => pe.PlanetExplorers)
                .ThenInclude(e => e.Explorer)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (planet == null)
                return NotFound();

            return Ok(PlanetDTOBuilder.BuildPlanetWithExplorersIdDTO(planet));
        }

        [HttpPost]
        public async Task<IActionResult> AddPlanet([FromBody] AddPlanetDTO planetDTO)
        {
            Planet planet = new()
            {
                Id = Guid.NewGuid(),
                Name = planetDTO.Name,
                Status = PlanetStatus.TODO,
                ImagePath = planetDTO.ImagePath
            };

            await _planetDbContext.Planets.AddAsync(planet);
            await _planetDbContext.SaveChangesAsync();

            return Ok(PlanetDTOBuilder.BuildPlanetDTO(planet));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePlanet([FromRoute] Guid id, PlanetWithExplorersDTO planetDTO)
        {
            // get planet from db
            var planet = await _planetDbContext.Planets
                .Include(pe => pe.PlanetExplorers)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (planet == null)
                return NotFound();

            planet.Description = planetDTO.Description;
            planet.Status = planetDTO.Status;

            // if captain add request exists
            if (planetDTO.Captain != null && planetDTO.Captain != "")
            {
                //try to get the captain
                var existingCaptain = _planetDbContext.PlanetExplorers
                    .FirstOrDefault(pe => pe.PlanetId == planetDTO.Id && pe.Explorer.Type == ExplorerType.Captain);

                // if there is already a captain - remove it
                if (existingCaptain != null && existingCaptain.ExplorerId != Guid.Parse(planetDTO.Captain))
                {
                    _planetDbContext.PlanetExplorers.Remove(existingCaptain);
                    await _planetDbContext.SaveChangesAsync();

                    var newCaptain = await _planetDbContext.Explorers
                        .FirstOrDefaultAsync(e => e.Id == Guid.Parse(planetDTO.Captain) && e.Type == ExplorerType.Captain);
                    var planetExplorerCaptain = new PlanetExplorer { Explorer = newCaptain, Planet = planet };
                    planet.PlanetExplorers.Add(planetExplorerCaptain);
                }

                //if planet not explored yet
                else if(existingCaptain == null)
                {
                    var captainToAdd = await _planetDbContext.Explorers
                        .FirstOrDefaultAsync(e => e.Id == Guid.Parse(planetDTO.Captain) && e.Type == ExplorerType.Captain);
                    var planetExplorerCaptain = new PlanetExplorer { Explorer = captainToAdd, Planet = planet };
                    planet.PlanetExplorers.Add(planetExplorerCaptain);
                }
         
            }

            // add the requested robots
            if (planetDTO.Robots != null && planetDTO.Robots.Count != 0)
            {
                foreach (var robotId in planetDTO.Robots)
                {
                    var robot = await _planetDbContext.Explorers
                        .FirstOrDefaultAsync(e => e.Id == Guid.Parse(robotId) && e.Type == ExplorerType.Robot);
                    if (robot != null)
                    {
                        var planetExplorerRobot = new PlanetExplorer { Explorer = robot, Planet = planet };
                        planet.PlanetExplorers.Add(planetExplorerRobot);
                    }
                }
            }

            await _planetDbContext.SaveChangesAsync();

            return Ok(PlanetDTOBuilder.BuildPlanetDTO(planet));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePlanet(Guid id)
        {
            var planet = await _planetDbContext.Planets.FindAsync(id);

            if (planet == null)
                return NotFound();

            _planetDbContext.Planets.Remove(planet);

            await _planetDbContext.SaveChangesAsync();

            return Ok(PlanetDTOBuilder.BuildPlanetDTO(planet));
        }

    }
}