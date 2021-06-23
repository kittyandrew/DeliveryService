using System;
using System.Collections.Generic;
using DeliveryService.Model;
using DeliveryService.Logic;

namespace DeliveryService.ConsoleView
{
    public class AddDeliveryView : BaseView
    {
        private readonly IDeliveryProc deliveryProc;
        private readonly IProductProc productProc;

        public AddDeliveryView(IDeliveryProc deliveryProc, IProductProc productProc)
        {
            this.deliveryProc = deliveryProc;
            this.productProc = productProc;
        }

        public void Menu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Adding delivery:");

                (Guid deliveryId, Guid transportId) = GetInputDelivery();
                Console.WriteLine($"\nSuccessfully created delivery: '{deliveryId}'!");
                Console.WriteLine($"Your delivery will be done by vehicle: '{transportId}'!");

                back = getNextMove("Go back to the main menu", "Add another delivery");
            }
            Console.WriteLine("\nExiting delivery creation menu...");
        }

        private (Guid, Guid) GetInputDelivery()
        {
            List<Product> products = new List<Product>();
            bool done = false;
            while (!done)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~");
                Console.Write    ("Type product id: ");

                String rawInput = Console.ReadLine();
                // Make sure it's not an empty string.
                if (rawInput == "")
                { 
                    Console.WriteLine($"Error: Product id can't be an empty string!");
                    continue;
                }

                Product product = productProc.GetProduct(rawInput);
                // Make sure product exists.
                if (product == null) {
                    Console.WriteLine($"Error: Product with id '{rawInput}' wasn't found!");
                    continue;
                }
                products.Add((Product)product);

                done = getNextMove("Move on", "Add another product");
            }

            int distance = -1;
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.Write    ("Type distance to the destination: ");

                String rawInput = Console.ReadLine();
                bool isNumeric = int.TryParse(rawInput, out distance);

                if (!isNumeric)
                    Console.WriteLine($"Error: Could not parse input as an integer: '{rawInput}'!");
                else if (distance <= 0 || distance > deliveryProc.GetMaxDistance())
                    Console.WriteLine($"Error: Input distance is unacceptable: {distance}! "
                                    + $"Delivery is available only in range of {deliveryProc.GetMaxDistance()}.");
                else
                    break;
            }
            Console.WriteLine($"Approximate delivery time: {deliveryProc.GetApproximateTime(distance)}");

            return deliveryProc.MakeDelivery(products, distance);
        }
    }
}
