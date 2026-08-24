using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace MiniProject.Models
{
    public class Menus
    {
        public static int ReadMenuSelection(int min, int max)
        {
            while (true)
            {
                Console.Write("Please make your selection: ");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                if (!int.TryParse(userInput, out int choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                if ( choice < min || choice > max)
                {
                    Console.WriteLine($"Please select a number between {min} and {max}.");
                    continue;
                }

                return choice;
            }
        }
        public static void DisplayWelcomeMenu()
        {
            Console.WriteLine("Welcome to Build-A-Rec! What would you like to do? ");
            Console.WriteLine();
            Console.WriteLine("1. Enter Build-A-Rec");
            Console.WriteLine("2. Find a Random Book");
            Console.WriteLine();
        }

        public static void EnterBuildARec(ref List<Book> filteredBooks)
        {
            Console.WriteLine("Let's start with the type of book: ");
            DisplayBookTypes(ref filteredBooks);
        }

        public static void DisplayBookTypes(ref List<Book> filteredBooks)
        {
            Console.WriteLine("1. AudioBooks");
            Console.WriteLine("2. Ebooks");
            Console.WriteLine("3. Physical Books");
            int choice = ReadMenuSelection(1, 3);
            switch (choice)
            {
                case 1:
                    filteredBooks = filteredBooks.Where(b => b is AudioBook).ToList();
                    break;
                case 2: 
                    filteredBooks = filteredBooks.Where(b => b is EBook).ToList();
                    break;
                case 3:
                    filteredBooks = filteredBooks.Where(b => b is PhysicalBook).ToList();
                    break;
            }
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

        public static void FindRandomBook()
        {
            var data = new MockData();
            var random = new Random();

            List<Book> allBooksList = data.AllBooks;

            var randomBook = allBooksList[random.Next(allBooksList.Count)];

            Console.WriteLine("\n--- Your Random Book ---\n");
            Console.WriteLine($"\"{randomBook.Title}\" by {randomBook.Author}");

            DisplayExitMenu();
        }

        public static void DisplayExitMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Start Over");
            Console.WriteLine("2. Exit");
            int choice = ReadMenuSelection(1, 2);
            switch (choice)
            {
                case 1:
                    return;
                case 2:
                    Console.WriteLine();
                    Environment.Exit(0);
                    return;     
            }
        }
    }
}
