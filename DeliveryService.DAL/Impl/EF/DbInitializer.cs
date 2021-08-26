using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DeliveryService.Entity;
using System.Threading.Tasks;

namespace DeliveryService.DAL.Impl.EF
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<DeliveryServiceContext>
    // class DbInitializer : DropCreateDatabaseAlways<DeliveryServiceContext>
    {
        protected override void Seed(DeliveryServiceContext context)
        {
            // Places

            context.Places.Add(new Place("Kyiv", 20, 0.1));
            context.Places.Add(new Place("Lviv", 400, 0.2));
            context.Places.Add(new Place("Odessa", 860, 0.3));
            context.Places.Add(new Place("Bila Tserkva", 65, 0.95));
            context.Places.Add(new Place("Vishneve", 10, 0.3));

            context.SaveChanges();

            // TransportTypes

            context.TransportTypes.Add(new TransportType("SUV", 25, 50, 100));
            context.TransportTypes.Add(new TransportType("Van", 50, 200, 80));
            context.TransportTypes.Add(new TransportType("Truck", 200, 750, 45));

            context.SaveChanges();

            // Transports

            context.Transports.Add(new Transport(DateTime.Now, 1));
            context.Transports.Add(new Transport(DateTime.Now, 1));
            context.Transports.Add(new Transport(DateTime.Now, 1));
            context.Transports.Add(new Transport(DateTime.Now, 2));
            context.Transports.Add(new Transport(DateTime.Now, 2));
            context.Transports.Add(new Transport(DateTime.Now, 3));
            context.Transports.Add(new Transport(DateTime.Now, 3));

            // ProductTypes

            context.ProductTypes.Add(new ProductType("Computers"));
            context.ProductTypes.Add(new ProductType("Television"));
            context.ProductTypes.Add(new ProductType("Soft Items"));
            context.ProductTypes.Add(new ProductType("Furniture"));
            context.ProductTypes.Add(new ProductType("Couches"));

            context.SaveChanges();

            // Products

            context.Products.Add(new Product("IPhone", 1, 0.1, 1));
            context.Products.Add(new Product("45' Samsung", 25, 40, 2));
            context.Products.Add(new Product("65' Samsung", 35, 75, 2));
            context.Products.Add(new Product("80' Samsung", 45, 100, 2));
            context.Products.Add(new Product("Small Pillow", 10, 3, 3));
            context.Products.Add(new Product("Big Pillow", 30, 10, 3));
            context.Products.Add(new Product("Chair", 85, 350, 4));
            context.Products.Add(new Product("Sofa", 180, 720, 5));

            context.SaveChanges();

            // TransportForProducts

            // Computers have all three types.
            context.TransportForProducts.Add(new TransportForProduct(1, 1));
            context.TransportForProducts.Add(new TransportForProduct(2, 1));
            context.TransportForProducts.Add(new TransportForProduct(3, 1));

            // Television has 2 bigger ones.
            context.TransportForProducts.Add(new TransportForProduct(2, 2));
            context.TransportForProducts.Add(new TransportForProduct(3, 2));

            // Soft Items have 2 lighter ones.
            context.TransportForProducts.Add(new TransportForProduct(1, 3));
            context.TransportForProducts.Add(new TransportForProduct(2, 3));

            // Furniture has two bigger ones.
            context.TransportForProducts.Add(new TransportForProduct(2, 4));
            context.TransportForProducts.Add(new TransportForProduct(3, 4));

            // Couches can only get moved via Truck.
            context.TransportForProducts.Add(new TransportForProduct(3, 5));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
