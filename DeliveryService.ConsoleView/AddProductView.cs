using System;
using DeliveryService.Model;
using DeliveryService.Logic;

namespace DeliveryService.ConsoleView
{
    public class AddProductView : BaseView
    {
        private readonly IProductProc productProc;

        public AddProductView(IProductProc productProc)
        {
            this.productProc = productProc;
        }

        public void Menu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Adding product:");

                ProductType productType = getInputProductType();
                Console.WriteLine($"\nSuccessfully parsed product type: '{productType}'!");

                String productName = getInputProductName();
                Console.WriteLine($"Successfully parsed product name: '{productName}'!");

                int productSize = getInputProductSize();
                Console.WriteLine($"Successfully parsed product name: '{productSize}'!");

                int productWeight = getInputProductWeight();
                Console.WriteLine($"Successfully parsed product name: '{productWeight}'!");

                Guid guid = productProc.MakeProduct(productType, productName, productSize, productWeight);
                Console.WriteLine( "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"Successfully created an product with id: '{guid}'!");

                back = getNextMove("Go back to the main menu", "Add another product");
            }
            Console.WriteLine("\nExiting product creation menu...");
        }

        private ProductType getInputProductType()
        {
            ProductType? productType = null;
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Type product type (options below):");
                Console.WriteLine("One of:");
                int index = -1;
                foreach (String enumName in Enum.GetNames(typeof(ProductType)))
                {
                    index++;
                    Console.WriteLine($"{index} - {enumName}");
                }

                Console.Write("Chosen index: ");
                char rawInput = (char)Console.Read();
                // Parsing input to enum if it's a digit.
                if (char.IsDigit(rawInput))
                    productType = (ProductType)int.Parse(rawInput.ToString());

                // Make sure it's not null (we parsed it correctly).
                if (productType == null)
                    Console.WriteLine($"\nError: Could not parse input as index: '{rawInput}'!");
                // Make sure we parsed to existing enum.
                else if (!Enum.IsDefined(typeof(ProductType), productType))
                    Console.WriteLine($"\nError: Could not parse input: '{productType}'!");
                // We are breaking on correct input.
                else
                    break;
            }
            // Explicit cast required, even though we only return when not null.
            return (ProductType)productType;
        }

        private String getInputProductName()
        {
            String productName = "";
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~");
                Console.Write    ("Type product name: ");
                productName = Console.ReadLine();

                // Make sure it's not an empty string.
                if (productName == "")
                    Console.WriteLine($"Error: Product name can't be an empty string!");
                else
                    break;
            }
            return productName;
        }

        private int getInputProductSize()
        {
            int productSize = -1;
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~");
                Console.Write    ("Type product size: ");

                String rawInput = Console.ReadLine();
                bool isNumeric = int.TryParse(rawInput, out productSize);

                if (!isNumeric)
                    Console.WriteLine($"Error: Could not parse input as an integer: {rawInput}!");
                else if (productSize <= 0 || productSize > productProc.GetMaxSize())
                    Console.WriteLine($"Error: Input size is unacceptable: {productSize}!");
                else
                    break;
            }
            return productSize;
        }

        private int getInputProductWeight()
        {
            int productWeight = -1;
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
                Console.Write    ("Type product weight: ");

                String rawInput = Console.ReadLine();
                bool isNumeric = int.TryParse(rawInput, out productWeight);

                if (!isNumeric)
                    Console.WriteLine($"Error: Could not parse input as an integer: {rawInput}!");
                else if (productWeight <= 0 || productWeight > productProc.GetMaxWeight())
                    Console.WriteLine($"Error: Input size is unacceptable: {productWeight}!");
                else
                    break;
            }   
            return productWeight;
        }
    }
}
