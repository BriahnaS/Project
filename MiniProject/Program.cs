using MiniProject.Models;
using MiniProject.Data;
using System.Linq;

var allBooks = new MockData(); // instantiate the MockData class to access the AllBooks property
List<Book> filteredBooks = allBooks.AllBooks; // Points to the list of all books in MockData. This list will be filtered as the user makes selections in the menus

while (true)
{
    Menus.DisplayWelcomeMenu();
    int choice = Menus.ReadMenuSelection(1, 2);

    if (choice == 1)
    {
        var result = Menus.EnterBuildARec(ref filteredBooks); // enterbuildarec returns a MenuResult enum value to see what the program should do next (continue, start over, or exit)

        if (result == MenuResult.Exit)
        {
            Console.WriteLine("Thank you for using Build-A-Rec! Goodbye!");
            break; // breaks out of the loop to end
        }
        if (result == MenuResult.StartOver)
        {
            Console.Clear();
            continue; // restarts the loop
        }
    }
    else if (choice == 2)
    {
        var result = Menus.FindRandomBook();
        if (result == MenuResult.StartOver)
        {
            Console.Clear();
            continue; // restarts the loop
        }
        if (result == MenuResult.Exit)
        {
            Console.WriteLine("Thank you for using Build-A-Rec! Goodbye!");
            break; 
        }
    }

}


