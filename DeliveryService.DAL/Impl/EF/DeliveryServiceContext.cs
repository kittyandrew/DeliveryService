using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Impl.EF
{
    public class DeliveryServiceContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<TransportForProduct> TransportForProducts { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Place> Places { get; set; }

        public DeliveryServiceContext() : base("Server=localhost;Database=DeliveryService;Trusted_Connection=True;")
        {
            Database.SetInitializer(new DbInitializer());
        }
    }
}
