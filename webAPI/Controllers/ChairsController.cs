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
    public class ChairsController : Controller {

        private readonly FurnitureContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ChairsController(FurnitureContext context, IWebHostEnvironment hosting) {
            _context = context;
            _hosting = hosting;
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