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
    public class LightsController : Controller {

        private readonly FurnitureContext _context;
        private readonly IWebHostEnvironment _hosting;

        public LightsController(FurnitureContext context, IWebHostEnvironment hosting) {
            _context = context;
            _hosting = hosting;
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