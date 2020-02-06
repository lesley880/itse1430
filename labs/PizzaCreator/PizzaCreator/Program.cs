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

        static string size;
        static string meat;
        static string vegtables;
        static string sauce;
        static bool cheese;
        static bool delivery;

        private static Command DisplayMenu ()
        {
            do
            {
                Console.WriteLine("N)ew Order: ");
                Console.WriteLine("D)isplay Order: ");
                Console.WriteLine("Q)uit.");

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "n": return Command.New;
                    case "d": return Command.Display;
                    case "q": return Command.Quit;

                    default: Console.WriteLine("Invalid option, please enter a valid letter. "); break;
                };
            } while (true);
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
            Size();
            Sauce();
            Cheese();
            Meat();
            Vegetables();
            Delivery();
        }

        private static bool Size ()
        {
            bool goodChoice;
            do
            {
                goodChoice = true;
                Console.WriteLine("Pizza size:\n S)mall(5.00)\n M)eduium(6.25)\n L)arge(8.75)");
                Console.Write("Choose one: ");
                var choice = Console.ReadLine();
                double cost = 0;

                switch (choice)
                {
                    case "S":
                    case "s":
                    cost += 5.00;
                    break;

                    case "M":
                    case "m":
                    cost += 6.25;
                    break;

                    case "L":
                    case "l":
                    cost += 8.75;
                    break;

                    default:
                    goodChoice = false;
                    Console.WriteLine("Invalid Selection please select S, M, or L");
                    break;
                }
            } while (!goodChoice);
            return (true);
        }

        private static bool Sauce ()
        {
            bool goodChoice;
            do
            {
                goodChoice = true;
                Console.WriteLine("Type of Sauce:\n T)raditional(0.00)\n G)arlic(1.00)\n O)regano(1.00)");
                Console.Write("Choose one: ");
                var choice = Console.ReadLine();
                double cost = 0;

                switch (choice)
                {
                    case "T":
                    case "t":
                    cost += 0.00;
                    break;

                    case "G":
                    case "g":
                    cost += 1.00;
                    break;

                    case "O":
                    case "o":
                    cost += 1.00;
                    break;

                    default:
                    goodChoice = false;
                    Console.WriteLine("Invalid Selection please select T, G, or O");
                    break;
                }
            } while (!goodChoice);
            return true;
        }

        private static bool Cheese()
        {
            bool choice;
            double cost = 0;
            Console.WriteLine(" R)egular($0.00)\n E)xtra($1.25) ");
            do
            {
                choice = true;
                string value = Console.ReadLine();
                if (!String.IsNullOrEmpty(value))
                {
                    if (String.Compare(value, "R", true) == 0)
                        return true;
                    else if (String.Compare(value, "E", true) == 0)
                        cost += 1.25;
                        choice = false;
                        return false;
                    char firstChar = value[0];
                };
                Console.WriteLine("Enter R/E ");
            } while (!choice);
            return true;
        }

        private static bool Meat ()
        {
            bool goodChoice;
            do
            {
                goodChoice = true;
                Console.WriteLine("Meat:\n B)acon(0.75)\n H)am(0.75)\n P)epperoni(0.75)\n S)ausage(0.75)\n N)one");
                Console.Write("Choose one: ");
                var choice = Console.ReadLine();
                double cost = 0;

                switch (choice)
                {
                    case "B":
                    case "b":
                    cost += 0.75;
                    break;

                    case "H":
                    case "h":
                    cost += 0.75;
                    break;

                    case "P":
                    case "p":
                    cost += 0.75;
                    break;

                    case "S":
                    case "s":
                    cost += 0.75;
                    break;

                    case "N":
                    case "n":
                    break;

                    default:
                    goodChoice = false;
                    Console.WriteLine("Invalid Selection please select B, H, P, S, or N");
                    break;
                }
            } while (!goodChoice);
            return true;
        }

        private static bool Vegetables ()
        {
            bool goodChoice;
            do
            {
                goodChoice = true;
                Console.WriteLine("Vegetables:\n B)lack olives(0.50)\n M)ushrooms(0.50)\n O)nions(0.50)\n P)eppers(0.50)\n N)one");
                Console.Write("Choose one: ");
                var choice = Console.ReadLine();
                double cost = 0;

                switch (choice)
                {
                    case "B":
                    case "b":
                    cost += 0.50;
                    break;

                    case "M":
                    case "m":
                    cost += 0.50;
                    break;

                    case "O":
                    case "o":
                    cost += 0.50;
                    break;

                    case "P":
                    case "p":
                    cost += 0.50;
                    break;

                    case "N":
                    case "n":
                    break;

                    default:
                    goodChoice = false;
                    Console.WriteLine("Invalid Selection please select B, M, O, P, or N");
                    break;
                }
            } while (!goodChoice);
            return true;
        }

        static bool Delivery()
        {
            double cost = 0;
            Console.WriteLine("T)akeout($0.00)\n D)elivery($1.25) ");
            do
            {
                string value = Console.ReadLine();
                if (!String.IsNullOrEmpty(value))
                {
                    if (String.Compare(value, "T", true) == 0)
                        return true;
                    else if (String.Compare(value, "D", true) == 0)
                        cost += 2.50;
                        return false;
                    char firstChar = value[0];
                };
                Console.WriteLine("Enter T/D ");
            } while (true);
        }

        private static void DisplayOrder()
        {
            if (String.IsNullOrEmpty(size))
            {
                Console.WriteLine("No Pizza Selected");
                return;
            }

            Console.WriteLine(Size());

            Console.WriteLine(sauce);

            Console.WriteLine(cheese ? "Cheese" : "No cheese");

            Console.WriteLine(meat);

            Console.WriteLine(vegtables);

            Console.WriteLine(delivery ? "Delivery" : "Take out");

        }
    }
}
