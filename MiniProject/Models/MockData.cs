using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace MiniProject.Models
{
    public class MockData
    {
        public List<AudioBook> audioBooks { get; } = new List<AudioBook>
        {
            new AudioBook { Author = "Sarah J. Maas", Title = "A Court of Thorns and Roses", BookGenre = Book.Genre.Fantasy, SingleNarration = true, GraphicAudio = true, Trope = new List<string> {"Found Family", "Enemies-to-Lovers", "Fated Love" },   },
            new AudioBook { Author = "Damien R. James", Title = "The Lone Hero 1", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", "World Building", }, Trope = new List<string> { "Lone Hero / One-Man Army", "High Stakes", "Relentless Antagonist", "Showdown", "Daring Escape / Chase Sequence" } },
            new AudioBook { Author = "Damien R. James", Title = "The Lone Hero 2", BookGenre = Book.Genre.Action,  Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", "World Building", }, Trope = new List<string> { "Lone Hero / One-Man Army", "High Stakes", "Relentless Antagonist", "Showdown", "Daring Escape / Chase Sequence" } },
            new AudioBook { Author = "Dakota Krout", Title = "World's Only Hero", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", "World Building", }, Trope = new List<string> {"Lone Hero / One-Man Army", "High Stakes", "Race Against Time", "Underdog Victory", "Mysterious Past"} },
            new AudioBook { Author = "Suzanne Brockmann", Title = "Forever Blue", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Romance", "Conflict", "Adventure", }, Trope = new List<string> { "Reluctant Hero", "High Stakes", "Showdown", "Daring Escape / Chase Sequence" } },
            new AudioBook { Author = "Brett Vogeler", Title = "The Reluctant Hero", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Personal Struggle", }, Trope = new List<string> { "Reluctant Hero", "High Stakes", "Race Against Time", "Relentless Antagonist" } },
            new AudioBook { Author = "Angela Douglas", Title = "The Mentor", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Side Character", "Personal Struggle", }, Trope = new List<string> { "Mentor-Student Dynamic", "Relentless Antagonist", "High Stakes", "Mysterious Past" } },
            new AudioBook { Author = "Andre Tkachev", Title = "The Strongest Student", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", "World Building", "Side Character" }, Trope = new List<string> { "Mentor-Student Dynamic", "Underdog Victory", "Showdown"} },
            new AudioBook { Author = "Boris Romanovsky", Title = "A Student Wants to Live", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", }, Trope = new List<string> { "Underdog Victory", "Relentless Antagonist", "Race Against Time" } },
            new AudioBook { Author = "Michael Benfante", Title = "Reluctant Hero", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", }, Trope = new List<string> { "Reluctant Hero", "Underdog Victory", "High Stakes" } },
            new AudioBook { Author = "Summer Lee", Title = "The Reluctant Hero Trilogy", BookGenre = Book.Genre.Action, Subplot = new List<string> { "Conflict", "Adventure", "Personal Struggle", "Side Character", }, Trope = new List<string> { "Reluctant Hero", "High Stakes", "Showdown", "Race Against Time" } }
        }; 

        public List<EBook> eBooks { get; } = new List<EBook>
        {
            new EBook { Author = "Tahereh Mafi", Title = "Shatter Me", BookGenre = Book.Genre.YoungAdult, AvailableOnKU = false, BookLength = "339 pages", Publisher = "StoryTide", SpecialEditionOrBonusContent = false, Subplot = new List<string> { "Dystopian Rebellion" }, Trope = new List<string> { "Enemies-to-Lovers", "Hidden Powers"} }
        };

        public List<PhysicalBook> physicalBooks { get; } = new List<PhysicalBook>
        {
            new PhysicalBook {Author = "Lindsey Richardson", Title = "Godsbane", BookGenre = Book.Genre.Fantasy, BookLength = "351 pages", PrintType = PhysicalBook.Type.Paperback, Publisher = "Fated Lore LLC", SpecialEditionOrBonusContent = false, Trope = new List<string> { "Bodyguard" } }
        };

        // Centralized collection of all books as Book instances to avoid repeating casts elsewhere
        //public List<Book> AllBooks => audioBooks.Cast<Book>().Concat(eBooks.Cast<Book>()).Concat(physicalBooks.Cast<Book>()).ToList();
        public List<Book> AllBooks => audioBooks.Concat<Book>(eBooks).Concat(physicalBooks).ToList();

    }
}
