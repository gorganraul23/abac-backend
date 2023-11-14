using AbacProjectBackend.Data;
using AbacProjectBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbacProjectBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ExplorerController : Controller
    {
        private readonly PlanetDbContext _planetDbContext;

        public ExplorerController(PlanetDbContext planetDbContext)
        {
            this._planetDbContext = planetDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExplorers()
        {
            var explorers = await _planetDbContext.Explorers.ToListAsync();

            return Ok(explorers);
        }

        [HttpPost]
        public async Task<IActionResult> AddExplorer([FromBody] Explorer explorer)
        {
            explorer.Id = Guid.NewGuid();

            await _planetDbContext.Explorers.AddAsync(explorer);
            await _planetDbContext.SaveChangesAsync();

            return Ok(explorer);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetExplorer(Guid id)
        {
            var explorer = await _planetDbContext.Explorers.FirstOrDefaultAsync(x => x.Id == id);

            if (explorer == null)
                return NotFound();
            return Ok(explorer);
        }

        [HttpGet]
        [Route("type/{type:int}")]
        public async Task<IActionResult> GetExplorerByType(ExplorerType type)
        {
            var explorers = await _planetDbContext.Explorers.Where(x => x.Type == type).ToListAsync();

            return Ok(explorers);
        }

    }
}
