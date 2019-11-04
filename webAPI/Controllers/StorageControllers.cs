using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class StorageController : Controller {

        private readonly FurnitureContext _context;

        public StorageController(FurnitureContext context) {
            _context = context;
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