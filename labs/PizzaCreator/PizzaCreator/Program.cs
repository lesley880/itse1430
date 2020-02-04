/* 
 *Lesley Reller
 *ITSE 1430
 *Spring 2020
 *PizzaCreator
 */
using System;

namespace PizzaCreator
{
    class Program
    {
        static void Main (string[] args)
        {
            var done = false;
            do
            {
                switch (DisplayMenu())
                {
                    case Command.New: NewOrder(); break;
                    case Command.Display: DisplayOrder(); break;
                    case Command.Quit: done = true; break;
                }
            } while (!done);
        }

        enum Command
        {
            Quit = 0,
            Display = 1,
            New = 2,
        }

        private static bool ReadBoolean (string message)
        {
            Console.WriteLine(message + " (Y/N) ");
            do
            {
                string value = Console.ReadLine();
                if (!String.IsNullOrEmpty(value))
                {
                    if (String.Compare(value, "Y", true) == 0)
                        return true;
                    else if (String.Compare(value, "N", true) == 0)
                        return false;
                    char firstChar = value[0];
                };
                Console.WriteLine("Enter Y/N: ");
            } while (true);
        }

        static void NewOrder()
        {
            do
            {
                Console.WriteLine("Pizza size: (choose one)");
                Console.WriteLine("Meat: ");
                Console.WriteLine("Vegetables: ");
                Console.WriteLine("Sauce: (choose one)");
                Console.WriteLine("Cheese: (choose one)");
                Console.WriteLine("Delivery: (choose one)");

            } while ();
        }

        static void DisplayOrder()
        {

        }

        private static Command DisplayMenu ()
        {
            do
            {
                Console.WriteLine("N)ew Order: ");
                Console.WriteLine("D)isplay Order: ");
                Console.WriteLine("Q)uit.");

                var input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "n": return Command.New;
                    case "d": return Command.Display;
                    case "q": return Command.Quit;

                    default: Console.WriteLine("Invalid option, please enter a valid letter. "); break;
                };
            } while (true);
        }
    }
}
