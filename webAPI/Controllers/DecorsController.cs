using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class DecorsController : Controller {

        private readonly FurnitureContext _context;

        public DecorsController(FurnitureContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Decor>> Get() {
            List<Decor> allDecors = await _context.Decor.ToListAsync();
            return allDecors;
        }

        [HttpPost]
        public async Task<Decor> Post(Decor newDecor) {
            _context.Decor.Add(newDecor);
            await _context.SaveChangesAsync();
            return newDecor;
        }

        [HttpPut]
        public async Task<Decor> Put(Decor updateDecor) {
            _context.Update(updateDecor);
            await _context.SaveChangesAsync();
            return updateDecor;
        }

        [HttpDelete("{id}")]
        public async Task<Decor> Delete(int id) {
            Decor decorToDelete = await _context.Decor.FirstAsync( decor => decor.Id == id );
            _context.Decor.Remove(decorToDelete);
            await _context.SaveChangesAsync();
            return decorToDelete;
        }
    }
}