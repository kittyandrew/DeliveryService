using DeliveryService.Abstr;
using DeliveryService.Model;
using System;
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

        public void ShowPlaces(IEnumerable<PlaceModel> placeModels)
        {
            Console.WriteLine("========== Available places ==========");
            Console.WriteLine($"{"Id",-5} | {"Name", -15} | {"Distance (km)",-5}");
            Console.WriteLine("--------------------------------------");
            foreach (PlaceModel placeModel in placeModels)
            {
                Console.WriteLine(
                    $"{placeModel.Id, -5} | {placeModel.Name, -15} | {placeModel.Distance, -5}"
                );
            }
            Console.WriteLine("======================================");
        }

        public void ShowProducts(IEnumerable<ProductModel> productModels)
        {
            Console.WriteLine("=== Available products ===");
            Console.WriteLine($"{"Id",-5} | {"Name",-15}");
            Console.WriteLine("--------------------------");
            foreach (ProductModel productModel in productModels)
            {
                Console.WriteLine($"{productModel.Id, -5} | {productModel.Name, -15}");
            }
            Console.WriteLine("===========================");
        }

        public void ShowDelivery(DeliveryModel deliveryModel)
        {
            Console.WriteLine("============== Your delivery ==============");
            Console.WriteLine($"{"Id:", -15}{deliveryModel.Id}");
            Console.WriteLine($"{"Product:", -15}{deliveryModel.ProductModel.Name}");
            Console.WriteLine($"Delivering to: {deliveryModel.PlaceModel.Name}");
            Console.WriteLine($"Expected time: {deliveryModel.DeliveryTime}");
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
