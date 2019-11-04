using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class SofasController : Controller {

        private readonly FurnitureContext _context;

        public SofasController(FurnitureContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Sofa>> Get() {
            List<Sofa> allSofas = await _context.Sofa.ToListAsync();
            return allSofas;
        }

        [HttpPost]
        public async Task<Sofa> Post(Sofa newSofa) {
            _context.Sofa.Add(newSofa);
            await _context.SaveChangesAsync();
            return newSofa;
        }

        [HttpPut]
        public async Task<Sofa> Put(Sofa updateSofa) {
            _context.Update(updateSofa);
            await _context.SaveChangesAsync();
            return updateSofa;
        }

        [HttpDelete("{id}")]
        public async Task<Sofa> Delete(int id) {
            Sofa sofaToDelete = await _context.Sofa.FirstAsync( sofa => sofa.Id == id );
            _context.Sofa.Remove(sofaToDelete);
            await _context.SaveChangesAsync();
            return sofaToDelete;
        }
    }
}