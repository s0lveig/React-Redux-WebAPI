using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TextilesController : Controller {

        private readonly FurnitureContext _context;

        public TextilesController(FurnitureContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Textile>> Get() {
            List<Textile> allTextiles = await _context.Textile.ToListAsync();
            return allTextiles;
        }

        [HttpPost]
        public async Task<Textile> Post(Textile newTextile) {
            _context.Textile.Add(newTextile);
            await _context.SaveChangesAsync();
            return newTextile;
        }

        [HttpPut]
        public async Task<Textile> Put(Textile updateTextile) {
            _context.Update(updateTextile);
            await _context.SaveChangesAsync();
            return updateTextile;
        }

        [HttpDelete("{id}")]
        public async Task<Textile> Delete(int id) {
            Textile textileToDelete = await _context.Textile.FirstAsync( textile => textile.Id == id );
            _context.Textile.Remove(textileToDelete);
            await _context.SaveChangesAsync();
            return textileToDelete;
        }
    }
}