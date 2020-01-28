/*
 * ITSE 1430
 * Lesley Reller
 */ 
using System;

namespace Section1
{
    class Program
    {
        static void Main ( string[] args )
        {
            // PlayingWithVariables();
            AddMovie ();
        }

        static void AddMovie ()
        {
            string title = ReadString("Enter a title: ", true);

            int releaseYear = ReadInt32("Enter the release year (>= 0): ", 0, 2100);
            int runLength = ReadInt32("Enter the run length (>= 0): ", 0, 86400);

            string description = ReadString("Enter a description: ", false);

            bool isClassic = ReadBoolean("Is this a classic movie?");
        }

        private static bool ReadBoolean ( string message )
        {
            Console.Write(message + " (Y/N) ");

            do
            {
                string value = Console.ReadLine();

                /* Check for empty string:
                     1. if (value != " ")
                     2. if (value != String.Empty)
                     3. if (value.Length == 0)
                     4. if (!String.IsNullOrEmpty(value))                 ~Preferred Approach~
                */

                if (!String.IsNullOrEmpty(value))
                    {
                    /* Input validation
                         1. String casing
                         2. String Comparison
                         3. If
                         4. Switch 
                    */


                    //value = value.ToLower();
                    //if (value == "y")
                    //    return true;
                    //else if (value == "n")
                    //    return false;

                    // bool isYes = String.Compare(value, "Y", true) == 0 ? true : false;  // popular Quiz Question

                    if (String.Compare(value, "Y", true) == 0)
                        return true;
                    else if (String.Compare(value, "N", true) == 0)
                        return false;

                    // Code below only looking for first letter so, York would be true, and New York would be false
                    char firstChar = value[0];
                    //if (firstChar == 'Y' || firstChar == 'y')
                    //    return true;
                    //else if (firstChar == 'N' || firstChar == 'n')
                    //    return false;


                    //switch (firstChar)
                    //{
                    //    //case 'A':
                    //    //{
                    //    //    Console.WriteLine("A"); 
                    //    //    break;
                    //    //};
                    //    //case 'a': Console.WriteLine("a"); break;

                    //    case 'Y':                   // fallback         ~Preferred Approach~
                    //    case 'y': return true;

                    //    case 'N': return false;     // no fallback
                    //    case 'n': return false;
                    //};
                };

                Console.Write("Enter Y/N: ");
            } while (true);
        }

        private static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            do
            {
                string value = Console.ReadLine();

                // if required and string is empty then error
                if (!String.IsNullOrEmpty(value) || !required)
                    return value;

                if (required)
                    Console.Write("Value is required: ");

            } while (true);
       
        
        }

        private static int ReadInt32 ( string message, int minValue, int maxValue )
        {
            Console.Write(message);
            do
            {
                // var is only allowed in local variable situations 
                var temp = Console.ReadLine();
                // int value = Int32.Parse(temp);

                //int value;
                if (Int32.TryParse(temp, out var value))
                {
                    if (value >= minValue && value <= maxValue)
                        return value;
                };

                Console.Write("Value must be between minValue and maxValue: ");
            } while (true);
        }

        private static void PlayingWithVariables ()
        {
            Console.WriteLine("Hello World!");

            int hours;
            double payRate;
            string name;
            bool pass;

            // hours = 10
            // int newHours = hours;

            // logical block 1
            int hours2 = 10;

            // int hours3;
            // hours3 = 3;

            int x, y, z;
            int a = 10, b = 20, c = 30;

            // Display a message
            Console.WriteLine("Enter a Value");
            Console.WriteLine(10);
            // void WriteLine (string msg)
            // string ReadLine()



            // logical block 2

            // incorrect/unnes
            //int results;
            //results = Foo();

            // proper
            //int results = Foo();j

            // takes no parameters and returns a string
            string input = Console.ReadLine();
        }
    }
}
