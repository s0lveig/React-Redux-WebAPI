using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    [Route("[controller]")]
    public class SofasController : Controller {

        private readonly FurnitureContext _context;
        private readonly IWebHostEnvironment _hosting;

        public SofasController(FurnitureContext context, IWebHostEnvironment hosting) {
            _context = context;
            _hosting = hosting;
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