using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class LightsController : Controller {

        private readonly FurnitureContext _context;

        public LightsController(FurnitureContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Lighting>> Get() {
            List<Lighting> allLighs = await _context.Lighting.ToListAsync();
            return allLighs;
        }

        [HttpPost]
        public async Task<Lighting> Post(Lighting newLighting) {
            _context.Lighting.Add(newLighting);
            await _context.SaveChangesAsync();
            return newLighting;
        }

        [HttpPut]
        public async Task<Lighting> Put(Lighting updateLighting) {
            _context.Update(updateLighting);
            await _context.SaveChangesAsync();
            return updateLighting;
        }

        [HttpDelete("{id}")]
        public async Task<Lighting> Delete(int id) {
            Lighting lightingToDelete = await _context.Lighting.FirstAsync( lighting => lighting.Id == id );
            _context.Lighting.Remove(lightingToDelete);
            await _context.SaveChangesAsync();
            return lightingToDelete;
        }
    }
}