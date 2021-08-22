using DeliveryService.Abstr;
using DeliveryService.Entity;
using System;
using DeliveryService.BLL.Abstr.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Impl
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void ShowInstructions()
        {
            Console.WriteLine("\nChoose option: ");
            Console.WriteLine("1: Get all products");
            Console.WriteLine("2: Get all places");
            Console.WriteLine("3: Order a delivery");
            Console.WriteLine("4: Show my delivery");
            Console.WriteLine("5: Cancel my delivery");
            Console.WriteLine("q: Exit application");
        }

        public void ShowPlaces(IEnumerable<Place> place)
        {
            Console.WriteLine("========== Available places ==========");
            Console.WriteLine($"{"Id",-5} | {"Name", -15} | {"Distance (km)",-5}");
            Console.WriteLine("--------------------------------------");
            foreach (Place placeModel in place)
            {
                Console.WriteLine(
                    $"{placeModel.Id, -5} | {placeModel.Name, -15} | {placeModel.Distance, -5}"
                );
            }
            Console.WriteLine("======================================");
        }

        public void ShowProducts(IEnumerable<Product> products)
        {
            Console.WriteLine("=== Available products ===");
            Console.WriteLine($"{"Id",-5} | {"Name",-15}");
            Console.WriteLine("--------------------------");
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Id, -5} | {product.Name, -15}");
            }
            Console.WriteLine("===========================");
        }

        public void ShowDelivery(Delivery delivery)
        {
            Console.WriteLine("============== Your delivery ==============");
            Console.WriteLine($"{"Id:",-15}{delivery.Id}");
            Console.WriteLine($"{"Product Id:",-15}{delivery.ProductId}");
            Console.WriteLine($"{"Place Id:", -15}{delivery.PlaceId}");
            Console.WriteLine($"Expected time: {delivery.DeliveryTime}");
            Console.WriteLine("===========================================");
        }

        public void Warn(string warning)
        {
            Console.WriteLine($"Warning: {warning}!");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Success: {message}!");
        }
    }
}
