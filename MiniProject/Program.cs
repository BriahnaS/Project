using MiniProject.Models;
using System.Linq;


var allBooks = new MockData();
List<Book> filteredBooks = allBooks.AllBooks;


while (true)
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

    // If any menu signaled a "start over", reset state and restart the main loop
    if (Menus.ShouldRestart)
    {
        Menus.ShouldRestart = false;
        filteredBooks = allBooks.AllBooks;
        continue;
    }
}


