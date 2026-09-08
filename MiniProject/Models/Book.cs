using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    public class Book
    {
        public Genre BookGenre { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public bool SpecialEditionOrBonusContent { get; set; }
        public List<string> Subplot { get; set; } = new List<string>();
        public List<string> Trope { get; set; } = new List<string>();
        public string BookLength { get; set; }

        public enum Genre
        {
            SciFi, 
            Action,
            Fantasy,
            Mystery,
            Thriller,
            Romance,
            Horror,
            HistoricalFiction,
            LiteraryFiction,
            YoungAdult,
            NewAdult,
            NonFiction,
        }
    }
}
