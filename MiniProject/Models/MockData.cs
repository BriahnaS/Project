using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    public class MockData
    {
        List<AudioBook> audiobooks = new List<AudioBook>
        {
            new AudioBook { Author = "Sarah J. Maas", Title = "A Court of Thorns and Roses", BookGenre = Book.Genre.Fantasy, SingleNarration = true, GraphicAudio = true, Trope = new List<string> {"Found Family", "Enemies to Lovers","etc" },   },
        }; 
    }
}
