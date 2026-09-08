using MiniProject.Models;
using System.Linq;


var allBooks = new MockData();
List<Book> filteredBooks = allBooks.AllBooks;


while (true)
{
    Menus.DisplayWelcomeMenu();
    int choice = Menus.ReadMenuSelection(1, 2);

    if (choice == 1)
    {
        var result = Menus.EnterBuildARec(ref filteredBooks);

        if (result == MenuResult.Exit)
            break;

        if (result == MenuResult.StartOver)
            continue;
    }
    else if (choice == 2)
    {
        var result = Menus.FindRandomBook();
        if (result == MenuResult.Exit)
            break;
    }

}

Environment.Exit(0);

