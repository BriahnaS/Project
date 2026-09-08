using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace MiniProject.Models
{
    public static class Menus
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

                if (choice < min || choice > max)
                {
                    Console.WriteLine($"Please select a number between {min} and {max}.");
                    continue;
                }

                return choice;
            }
        }
        public static void DisplayWelcomeMenu()
        {
            Console.WriteLine("Welcome to Build-A-Rec! What would you like to do?\n");
            Console.WriteLine("1. Enter Build-A-Rec");
            Console.WriteLine("2. Find a Random Book");
            Console.WriteLine();
        }

        public static void EnterBuildARec(ref List<Book> filteredBooks)
        {
            Console.WriteLine("Let's start with the type of book: \n");
            DisplayBookTypes(ref filteredBooks);
            Book.Genre genre = 0;
            DisplayGenreMenu(ref filteredBooks, ref genre);
            DisplaySubplotMenu(ref genre, ref filteredBooks);
            DisplayTropeMenu(ref genre, ref filteredBooks);

        }

        public static void DisplayBookTypes(ref List<Book> filteredBooks)
        {
            Console.WriteLine("1. AudioBooks");
            Console.WriteLine("2. Ebooks");
            Console.WriteLine("3. Physical Books");
            Console.WriteLine();
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

        public static void FindBook(ref List<Book> filteredBooks)
        {

            if (filteredBooks.Count == 0)
            {
                Console.WriteLine("Oh no! We don't have any books that match your search. \n");
                Console.WriteLine("Please try again later, or change your criteria.");
            }
            else
            {
                Console.WriteLine("--- Books That Fit Your Criteria ---\n");
                foreach (Book book in filteredBooks)
                {
                    Console.WriteLine($"\"{book.Title}\" by {book.Author}");
                }
            }
            DisplayExitMenu();
        }

        public static void DisplayGenreMenu(ref List<Book> filteredBooks, ref Book.Genre genre)
        {
            Console.WriteLine("Now let's find a genre: \n");
            while (true)
            {
                int index = 1;

                var genres = Enum.GetValues(typeof(Book.Genre)).Cast<Book.Genre>().ToList();
                foreach (var g in genres) // Have to reference Book since it's in that class duh
                {
                    Console.WriteLine($"{index}. {g}");
                    index++;
                }
                Console.WriteLine($"{index}. Move to Subplots");
                int moveToSubplots = index;
                index++;

                Console.WriteLine($"{index}. Find Books");
                int findBooks = index;
                Console.WriteLine();

                int choice = ReadMenuSelection(1, index);
                if (choice <= genres.Count)
                {
                    genre = genres[choice - 1];
                    filteredBooks = filteredBooks.Where(b => b.BookGenre == genres[choice]).ToList();
                    continue;
                }
                if (choice == moveToSubplots)
                {
                    return;
                }
                if (choice == findBooks)
                {
                    FindBook(ref filteredBooks);
                }
            }
        }

        public static void DisplaySubplotMenu(ref Book.Genre genre, ref List<Book> filteredBooks)
        {
            while (true)
            {
                int index = 1;
                if (SubplotLibrary.SubplotsByGenre.TryGetValue(genre, out var subplots))
                {
                    Console.WriteLine($"Subplots for {genre}: \n");
                    foreach (var sp in subplots)
                    {
                        Console.WriteLine($"{index}. {sp}");
                        index++;
                    }
                }
                Console.WriteLine($"{index}. Move to Tropes");
                int moveToTropes = index;
                index++;

                Console.WriteLine($"{index}. Find Books\n");
                int findBooks = index;

                int choice = ReadMenuSelection(1, index);
                if (choice <= subplots.Count)
                {
                    string selectedSubplot = subplots[choice - 1];
                    filteredBooks = filteredBooks.Where(b => b.Subplot == selectedSubplot).ToList();
                    continue;
                }
                if (choice == moveToTropes)
                {
                    return;
                }
                if (choice == findBooks)
                {
                    FindBook(ref filteredBooks);
                }
            }
        }

        public static void DisplayTropeMenu(ref Book.Genre genre, ref List<Book> filteredBooks)
        {
            while (true)
            {
                int index = 1;
                if (TropeLibrary.TropesByGenre.TryGetValue(genre, out var tropes))
                {
                    Console.WriteLine($"Tropes for the {genre} genre: ");
                    foreach (var trope in tropes)
                    {
                        Console.WriteLine($"{index}. {trope}");
                        index++;
                    }
                    Console.WriteLine($"{index}. Find Books");
                    int findBookOption = index;

                    int choice = ReadMenuSelection(1, index);
                    if (choice <= tropes.Count)
                    {
                        string selectedTrope = tropes[choice - 1];
                        filteredBooks = filteredBooks.Where(b => b.Trope != null && b.Trope.Contains(selectedTrope)).ToList();
                    }
                    if (choice == findBookOption)
                    {
                        FindBook(ref filteredBooks);
                    }
                }
            }
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
            Console.WriteLine("What would you like to do now?\n");
            Console.WriteLine("1. Start Over");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            int choice = ReadMenuSelection(1, 2);
            switch (choice)
            {
                case 1:
                    // signal to Program.cs that the user wants to start over
                    ShouldRestart = true;
                    return;
                case 2:
                    return;
            }
        }
    }
}
