using MiniProject.Models;
using System.Linq;
// 19 Aug ToDo List - create mock data base or find database/api
bool running = true;
var allBooks = new MockData();
List<Book> filteredBooks = allBooks.AllBooks;


while (running)
{
    Menus.DisplayWelcomeMenu();
    int choice = Menus.ReadMenuSelection(1, 2);
    switch (choice)
    {
        case 1:
            Menus.EnterBuildARec(ref filteredBooks);
            break;
        case 2:
            Menus.FindRandomBook();
            break;
    }
}




// Find a way to call an action based on user input


// Create hardcoded dataset

// - Each option selection will add whatever the user selection was to the list created at the start of the program
// Build LINQ filtering method that get added to based on user selction

// Build end of selection menu 
//Console.WriteLine("Please make a selection: ");
//Console.WriteLine("1. Exit");
//Console.WriteLine("2. Start Over");

