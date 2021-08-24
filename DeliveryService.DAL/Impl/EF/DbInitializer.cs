using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Impl.EF
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<DeliveryServiceContext>
    // class DbInitializer : DropCreateDatabaseAlways<DeliveryServiceContext>
    {
        protected override void Seed(DeliveryServiceContext context)
        {
            ICollection<Place> places = new List<Place>
            {
                new Place { Name = "Kyiv", Distance = 20, Traffic = 0.1 },
                new Place { Name = "Lviv", Distance = 400, Traffic = 0.2 },
                new Place { Name = "Odessa", Distance = 860, Traffic = 0.3 },
                new Place { Name = "Bila Tserkva", Distance = 65, Traffic = 0.95 },
                new Place { Name = "Vishneve", Distance = 10, Traffic = 0.3 }
            };

            foreach (Place place in places)
                context.Places.Add(place);

            ICollection<TransportType> transportTypes = new List<TransportType>
            {
                new TransportType { Name = "SUV", MaxSize = 25, MaxWeight = 50, Speed = 100 },
                new TransportType { Name = "Van", MaxSize = 50, MaxWeight = 200, Speed = 80 },
                new TransportType { Name = "Truck", MaxSize = 200, MaxWeight = 750, Speed = 45 }
            };

            foreach (TransportType transportType in transportTypes)
                context.TransportTypes.Add(transportType);

            context.SaveChanges();

            ICollection<Transport> transports = new List<Transport>
            {
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 1 },
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 1 },
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 1 },
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 2 },
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 2 },
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 3 },
                new Transport { FreeBy = DateTime.Now, TransportTypeId = 3 }
            };

            foreach (Transport transport in transports)
                context.Transports.Add(transport);

            ICollection<Product> products = new List<Product>
            {
                new Product { Name = "IPhone", Size = 1, Weight = 0.1 },
                new Product { Name = "45' Samsung", Size = 25, Weight = 40 },
                new Product { Name = "65' Samsung", Size = 35, Weight = 75 },
                new Product { Name = "80' Samsung", Size = 45, Weight = 100 },
                new Product { Name = "Small Pillow", Size = 10, Weight = 3 },
                new Product { Name = "Big Pillow", Size = 30, Weight = 10 },
                new Product { Name = "Chair", Size = 85, Weight = 350 },
                new Product { Name = "Sofa", Size = 180, Weight = 720 }
            };

            foreach (Product product in products)
                context.Products.Add(product);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
