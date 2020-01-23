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
            string value = Console.ReadLine();

            //TODO: Do this correctly!
            char firstChar = value[0];
            return firstChar == 'Y';
        }

        private static string ReadString ( string message, bool required )
        {
            Console.Write(message);
            string value = Console.ReadLine();

            //TODO: Validate
            return value;
        }

        private static int ReadInt32 ( string message, int minValue, int maxValue )
        {
            Console.Write(message);

            string temp = Console.ReadLine();

            // int value = Int32.Parse(temp);
            int value;
            if (Int32.TryParse(temp, out value))
                return value;

            //TODO: Validate input
            return -1;
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
