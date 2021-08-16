using System;
using System.Data.Entity;
using DeliveryService.Entity;

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

        public DeliveryServiceContext() : base("Server=localhost;Database=DeliveryService;Trusted_Connection=True;") {
            Database.SetInitializer<DeliveryServiceContext>(new DbInitializer());
        }
    }
}