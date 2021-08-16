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
            Console.WriteLine(string.Format(
                "{0} | {1} | {2}", "Id".PadRight(5), "Name".PadRight(15), "Distance (km)".PadRight(5)
            ));
            Console.WriteLine("--------------------------------------");
            foreach (PlaceModel placeModel in placeModels)
            {
                string id = placeModel.Id.ToString().PadRight(5, ' ');
                string name = placeModel.Name.ToString().PadRight(15, ' ');
                string distance = placeModel.Distance.ToString().PadRight(5, ' ');
                Console.WriteLine(id + " | " + name + " | " + distance);
            }
            Console.WriteLine("======================================");
        }

        public void ShowProducts(IEnumerable<ProductModel> productModels)
        {
            Console.WriteLine("=== Available products ===");
            Console.WriteLine(string.Format(
                "{0} | {1}", "Id".PadRight(5), "Name".PadRight(15)
            ));
            Console.WriteLine("--------------------------");
            foreach (ProductModel productModel in productModels)
            {
                string id = productModel.Id.ToString().PadRight(5, ' ');
                string name = productModel.Name.ToString().PadRight(15, ' ');
                Console.WriteLine(id + " | " + name);
            }
            Console.WriteLine("===========================");
        }

        public void ShowDelivery(DeliveryModel deliveryModel)
        {
            Console.WriteLine("============== Your delivery ==============");
            Console.WriteLine("Id: ".PadRight(15, ' ') + deliveryModel.Id);
            Console.WriteLine("Product: ".PadRight(15, ' ') + deliveryModel.ProductModel.Name);
            Console.WriteLine("Delivering to: ".PadRight(15, ' ') + deliveryModel.PlaceModel.Name);
            Console.WriteLine("Expected time: ".PadRight(15, ' ') + deliveryModel.DeliveryTime);
            Console.WriteLine("===========================================");
        }

        public void Warn(string warning)
        {
            Console.WriteLine("Warning: " + warning + "!");
        }

        public void Info(string message)
        {
            Console.WriteLine("Success: " + message + "!");
        }
    }
}
