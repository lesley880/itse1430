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
        static void Main ( string[] args )
        {
            //var userInput = 0;
            //do
            //{
            //    userInput = DisplayMenu();
            //} while (userInput!=5);

            bool showMenu = true;
            while (showMenu)
            {
                MainMenu();
            }
            
            Display();
        }

        private static bool MainMenu()
        {
            Console.WriteLine("   Menu ");
            Console.WriteLine("1. poop ");
            Console.WriteLine("2. poo");
            Console.WriteLine("3. po");
            Console.WriteLine("4. p");
            Console.WriteLine("5. Quit");
            Console.WriteLine("");
            Console.Write("Select an Option: ");

            switch (Console.ReadLine())
            {
                case "1":
                Display();
                return true;

                case "2":
                Display();
                return true;

                case "3":
                Display();
                return true;

                case "4":
                Display();
                return true;

                case "5":
                Display();
                return true;

            }


            return false;
        }

        static int Display()
        {
            return 0;
        }
        //static public int DisplayMenu()
        //{
        //    Console.WriteLine("1. poop ");
        //    Console.WriteLine("2. poo");
        //    Console.WriteLine("3. po");
        //    Console.WriteLine("4. p");
        //    Console.WriteLine("5. Quit");

        //    var result = Console.ReadLine();
        //    return Convert.ToInt32(result);
        //}
    }
}
