﻿/*
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
            var done = false;
            do
            {
                switch(DisplayMenu())
                {
                    case Command.Add: AddMovie(); break;
                    case Command.Display: DisplayMovie(); break;
                    case Command.Quit: done = true; break;
                };
            }while (!done);
        }
        enum Command
        {
            Quit =0,
            Add = 1,
            Display = 2,
        }


        private static void DisplayMovie()
        {
            if (String.IsNullOrEmpty(title))
            {
                Console.WriteLine("No Movies");
                return;
            };

            Console.WriteLine(title);

            Console.WriteLine(releaseYear);

            Console.WriteLine(runLength + " (min)");

            if (!String.IsNullOrEmpty(description))
            Console.WriteLine(description);

            Console.WriteLine(isClassic ? "Classic" : "Not Classic");
        }

        private static Command DisplayMenu ()
        {
            do
            {
                Console.WriteLine("A)dd movie");
                Console.WriteLine("D)isplay Movie");
                Console.WriteLine("Q)uit");

                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "a": return Command.Add;
                    case "d": return Command.Display;
                    case "q": return Command.Quit;

                    default: Console.WriteLine("Invalid option"); break;
                };
            } while (true);
        }

            static string title;
            static int releaseYear;
            static int runLength;
            static string description;
            static bool isClassic;


        static void AddMovie ()
        {
            title = ReadString("Enter a title: ", true);

            releaseYear = ReadInt32("Enter the release year (>= 0): ", 0, 2100);
            runLength = ReadInt32("Enter the run length (>= 0): ", 0, 86400);

            description = ReadString("Enter a description: ", false);

            isClassic = ReadBoolean("Is this a classic movie?");
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
        static void PlayingWithString ()
        {
            var firstName = "Bob";
            var lastName = "Jones";

            var fullName = firstName + lastName;
            fullName += "Jr";

            // Concat more than six
            var concat = String.Concat(firstName, " ", lastName);
            var joined = String.Join(" ", firstName, lastName);

            // Formatting
            Console.WriteLine("First Name: {0} Last Name {1}", firstName, lastName);
            var format = String.Format("First Name: {0} Last Name: {1}", firstName, lastName);
            var format2 = "First Name: " + firstName + " Last Name: " + lastName;

            // Preferred - string interpolation
            var format3 = $"First Name: {firstName} Last Name: {lastName}";
            // $ indicates string interpolation

            // verbatim string
            var path = @"c:\windows\system32";

            var startsWithSlash = path.StartsWith(@"\");
            var endsWithSlash = path.EndsWith(@"\");

            var padLeft = fullName.PadLeft(20);
            var padRight = fullName.PadRight(20);
            var header = "".PadLeft(20, '-'); // "-----"

            var trim = fullName.Trim();
            var trimStart = fullName.TrimStart();
            var trimEnd = fullName.TrimEnd();
            var trimSlash = path.Trim('\\', '-');

            var tokens = path.Split('\\');

        }
    }
}
