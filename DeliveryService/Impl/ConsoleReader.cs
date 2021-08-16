using DeliveryService.Abstr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Impl
{
    public class ConsoleReader : IConsoleReader
    {
        public char GetTask()
        {
            Console.Write("Enter next command: ");
            char task = Console.ReadKey().KeyChar;
            // Add new line, so it seems like we pressed enter.
            Console.WriteLine();
            return task;
        }

        public int GetPlaceId()
        {
            Console.Write("Enter id of the place: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetProductId()
        {
            Console.Write("Enter id of the product: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
