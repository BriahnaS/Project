using MiniProject.Models;
// 17 Aug ToDo List - create mock data base or find dtabase/api
string userInput = "";

Menus.DisplayWelcomeMenu();
Menus.ReadMenuSelection(ref userInput, 1, 2);
Console.WriteLine($"You have selected {userInput}.");
Menus.DisplayGenreMenu();
//Menus.ReadMenuSelection(ref userInput);

//Console.WriteLine($"You have selected {userInput}.");
// Build classes
// Create hardcoded dataset
// Build lists of objects of type book (or child classes)
// - Each option selection will add whatever the user selection was to the list created at the start of the program
// Build LINQ filtering method that get added to based on user selction

// Build end of selection menu 
//Console.WriteLine("Please make a selection: ");
//Console.WriteLine("1. Exit");
//Console.WriteLine("2. Start Over");

