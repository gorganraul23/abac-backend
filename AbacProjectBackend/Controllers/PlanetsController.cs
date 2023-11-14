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
            var planets = await _planetDbContext.Planets.Include(p => p.Captain).ToListAsync();

            var planetsDTO = planets.Select(planet => PlanetDTOBuilder.BuildPlanetWithCaptainDTO(planet));
            return Ok(planetsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetPlanet(Guid id)
        {
            var planet = await _planetDbContext.Planets.Include(p => p.Captain).FirstOrDefaultAsync(x => x.Id == id);

            if (planet == null)
                return NotFound();

            return Ok(PlanetDTOBuilder.BuildPlanetDTO(planet));
            //return Ok(planet);
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
        public async Task<IActionResult> UpdatePlanet([FromRoute] Guid id, UpdatePlanetDTO planetDTO)
        {
            // get planet from db
            var planet = await _planetDbContext.Planets.FindAsync(id);

            if (planet == null)
                return NotFound();

            if(planetDTO.Captain != null)
            {
                planet.Description = planetDTO.Description;
                var captain = await _planetDbContext.Explorers.FindAsync(planetDTO.Captain);
                if (captain == null || captain.Type != ExplorerType.Captain)
                    return NotFound();
                planet.Captain = captain;
            }

            switch (planetDTO.Status)
            {
                case 0:
                    planet.Status = PlanetStatus.TODO;
                    break;

                case 1:
                    planet.Status= PlanetStatus.EnRoute;
                    break;

                case 2:
                    planet.Status = PlanetStatus.OK;
                    break;

                default:
                    planet.Status = PlanetStatus.NotOK;
                    break;
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