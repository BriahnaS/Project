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
            new AudioBook { Author = "Sarah J. Maas", Title = "A Court of Thorns and Roses", BookGenre = Book.Genre.Fantasy, SingleNarration = true, GraphicAudio = true, Trope = new List<string> {"Found Family", "Enemies to Lovers","etc" },   },
        }; 

        public List<EBook> eBooks { get; } = new List<EBook>
        {
            new EBook { Author = "Tahereh Mafi", Title = "Shatter Me", BookGenre = Book.Genre.YoungAdult, AvailableOnKU = false, BookLength = "339 pages", Publisher = "StoryTide", SpecialEditionOrBonusContent = false, Subplot = "Dystopian", Trope = new List<string> { "Enemies to Lovers", "Strong Heroine"} }
        };

        public List<PhysicalBook> physicalBooks { get; } = new List<PhysicalBook>
        {
            new PhysicalBook {Author = "Lindsey Richardson", Title = "Godsbane", BookGenre = Book.Genre.Fantasy, BookLength = "351 pages", PrintType = PhysicalBook.Type.Paperback, Publisher = "Fated Lore LLC", SpecialEditionOrBonusContent = false,  }
        };

        // Centralized collection of all books as Book instances to avoid repeating casts elsewhere
        public List<Book> AllBooks => audioBooks.Cast<Book>().Concat(eBooks.Cast<Book>()).Concat(physicalBooks.Cast<Book>()).ToList();
    }
}
