using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ChairsController : Controller {

        private readonly FurnitureContext _context;

        public ChairsController(FurnitureContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Chair>> Get() {
            List<Chair> allChairs = await _context.Chair.ToListAsync();
            return allChairs;
        }

        [HttpPost]
        public async Task<Chair> Post(Chair newChair) {
            _context.Chair.Add(newChair);
            await _context.SaveChangesAsync();
            return newChair;
        }

        [HttpPut]
        public async Task<Chair> Put(Chair updateChair) {
            _context.Update(updateChair);
            await _context.SaveChangesAsync();
            return updateChair;
        }

        [HttpDelete("{id}")]
        public async Task<Chair> Delete(int id) {
            Chair chairToDelete = await _context.Chair.FirstAsync( chair => chair.Id == id );
            _context.Chair.Remove(chairToDelete);
            await _context.SaveChangesAsync();
            return chairToDelete;
        }
    }
}