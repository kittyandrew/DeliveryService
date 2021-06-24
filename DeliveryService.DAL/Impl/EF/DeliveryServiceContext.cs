using Microsoft.EntityFrameworkCore;
using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.DAL.Impl.EF
{
    public class DeliveryServiceContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DeliveryServiceDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryModel>().ToTable("Deliveries");
            modelBuilder.Entity<PlaceModel>().ToTable("Places");
            modelBuilder.Entity<ProductModel>().ToTable("Products");
            modelBuilder.Entity<ProductTypeModel>().ToTable("ProductTypes");
            modelBuilder.Entity<TransportModel>().ToTable("Transports");
            modelBuilder.Entity<TransportTypeModel>().ToTable("TransportTypes");
        }
    }
}