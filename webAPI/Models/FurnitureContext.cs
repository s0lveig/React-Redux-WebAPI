using Microsoft.EntityFrameworkCore;

namespace webAPI.Models {

    public class FurnitureContext : DbContext {

        public FurnitureContext(DbContextOptions<FurnitureContext> options) : base(options){}

        public DbSet<Chair> Chair { get; set; }
        public DbSet<Sofa> Sofa { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Lighting> Lighting { get; set; }
        public DbSet<Textile> Textile { get; set; }
        public DbSet<Decor> Decor { get; set; }
    }
}