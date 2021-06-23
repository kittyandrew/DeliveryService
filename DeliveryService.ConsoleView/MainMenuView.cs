using System;
using DeliveryService.Dao;
using DeliveryService.Model;
using DeliveryService.Logic;

namespace DeliveryService.ConsoleView
{
    public class MainMenuView
    {
        private readonly IProductProc productProc;
        private readonly IDeliveryProc deliveryProc;

        private AddProductView addProductView;
        private AddDeliveryView addDeliveryView;

        public MainMenuView(IProductProc productProc, IDeliveryProc deliveryProc)
        {
            this.productProc = productProc;
            this.deliveryProc = deliveryProc;

            addProductView = new AddProductView(productProc);
            addDeliveryView = new AddDeliveryView(deliveryProc, productProc);
        }

        public void Menu()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Main menu options:");
                Console.WriteLine($"0 - Register new product");
                Console.WriteLine($"1 - Register new delivery");
                Console.WriteLine($"2 - Confirm successfull delivery");
                Console.WriteLine($"3 - Cancel delivery");
                Console.WriteLine($"4 - Quit");
                Console.Write    ("Chosen index: ");

                char rawInput = (char)Console.Read();
                quit = GetNextMove(rawInput);
            }
            Console.WriteLine("\nClosing the application...");
        }

        public bool GetNextMove(char rawInput)
        {
            int nextMove;

            if (!char.IsDigit(rawInput))
            {
                Console.WriteLine($"\nError: Could not parse input as index: '{rawInput}'!");
                return false;
            }

            nextMove = int.Parse(rawInput.ToString());
            switch (nextMove)
            {
                case 0:
                    addProductView.Menu();
                    return false;
                case 1:
                    addDeliveryView.Menu();
                    return false;
                case 2:
                case 3:
                    throw new NotImplementedException("RIP");
                case 4:
                    return true;
                default:
                    Console.WriteLine($"\nError: Not a valid input option: '{nextMove}'!");
                    return false;
            }
        }
    }
}
