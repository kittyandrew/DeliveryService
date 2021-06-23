using System;
namespace DeliveryService.ConsoleView
{
    public class BaseView
    {
        protected bool getNextMove(String option0, String option1)
        {
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Type what do you want to do next (options below):");
                Console.WriteLine("One of:");
                Console.WriteLine($"0 - {option0}");
                Console.WriteLine($"1 - {option1}");
                Console.Write    ("Chosen index: ");

                int nextMove;
                char rawInput = (char)Console.Read();

                Console.WriteLine("");
                if (!char.IsDigit(rawInput))
                {
                    Console.WriteLine($"Error: Could not parse input as index: '{rawInput}'!");
                    continue;
                }

                nextMove = int.Parse(rawInput.ToString());
                switch (nextMove)
                {
                    case 0:
                        return true;
                    case 1:
                        return false;
                    default:
                        Console.WriteLine($"Error: Not a valid input option: '{nextMove}'!");
                        break;
                }
            }
        }
    }
}
