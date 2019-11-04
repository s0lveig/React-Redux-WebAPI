using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TablesController : Controller {

        private readonly FurnitureContext _context;

        public TablesController(FurnitureContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Table>> Get() {
            List<Table> allTables = await _context.Table.ToListAsync();
            return allTables;
        }

        [HttpPost]
        public async Task<Table> Post(Table newTable) {
            _context.Table.Add(newTable);
            await _context.SaveChangesAsync();
            return newTable;
        }

        [HttpPut]
        public async Task<Table> Put(Table updateTable) {
            _context.Update(updateTable);
            await _context.SaveChangesAsync();
            return updateTable;
        }

        [HttpDelete("{id}")]
        public async Task<Table> Delete(int id) {
            Table tableToDelete = await _context.Table.FirstAsync( table => table.Id == id );
            _context.Table.Remove(tableToDelete);
            await _context.SaveChangesAsync();
            return tableToDelete;
        }
    }
}