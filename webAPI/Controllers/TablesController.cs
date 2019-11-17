using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using webAPI.Models;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    [Route("[controller]")]
    public class TablesController : Controller {

        private readonly FurnitureContext _context;
        private readonly IWebHostEnvironment _hosting;

        public TablesController(FurnitureContext context, IWebHostEnvironment hosting) {
            _context = context;
            _hosting = hosting;
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

        [HttpPost]
        [Route("[action]")]
        public void uploadImg(IFormFile file) {
            string webrootpath = _hosting.WebRootPath;
            string absolutepath = Path.Combine($"{webrootpath}/images/{file.FileName}");
            using(var filestream = new FileStream(absolutepath, FileMode.Create)) {
                file.CopyTo(filestream);
            }
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