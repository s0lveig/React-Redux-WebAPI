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
    public class StorageController : Controller {

        private readonly FurnitureContext _context;
        private readonly IWebHostEnvironment _hosting;

        public StorageController(FurnitureContext context, IWebHostEnvironment hosting) {
            _context = context;
            _hosting = hosting;
        }

        [HttpGet]
        public async Task<IEnumerable<Storage>> Get() {
            List<Storage> allStorage = await _context.Storage.ToListAsync();
            return allStorage;
        }

        [HttpPost]
        public async Task<Storage> Post(Storage newStorage) {
            _context.Storage.Add(newStorage);
            await _context.SaveChangesAsync();
            return newStorage;
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
        public async Task<Storage> Put(Storage updateStorage) {
            _context.Update(updateStorage);
            await _context.SaveChangesAsync();
            return updateStorage;
        }

        [HttpDelete("{id}")]
        public async Task<Storage> Delete(int id) {
            Storage storageToDelete = await _context.Storage.FirstAsync( storage => storage.Id == id );
            _context.Storage.Remove(storageToDelete);
            await _context.SaveChangesAsync();
            return storageToDelete;
        }
    }
}