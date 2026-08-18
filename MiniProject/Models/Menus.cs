using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    public class Menus
    {
        public static int ReadMenuSelection(ref string userInput, int min, int max)
        {
            while (true)
            {
                Console.Write("Please make your selection: ");
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (!int.TryParse(userInput, out int choice))
                {
                    Console.WriteLine("Please enter a valid number.");

                    continue;
                }

                return choice;
            }

        }

        //public static int GetMenuChoice(string prompt, int min, int max)
        //{
        //    Console.WriteLine(prompt);
        //    return ReadMenuSelection(userInput, min, max);
        //}

        public static void DisplayWelcomeMenu()
        {
            Console.WriteLine("Welcome to Build-A-Rec! What would you like to do? ");
            Console.WriteLine();
            Console.WriteLine("1. Enter Build-A-Rec");
            Console.WriteLine("2. Find a Random Book");
            Console.WriteLine();
        }

        public static void DisplayGenreMenu()
        {
            int index = 1;
            foreach (Book.Genre g in Enum.GetValues(typeof(Book.Genre))) // Have to reference Book since it's in that class duh
            {
                Console.WriteLine($"{index}. {g}");
                index++;
            }
            Console.WriteLine();
        }
    }
}
