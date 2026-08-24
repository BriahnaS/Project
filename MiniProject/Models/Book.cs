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
        public string Subplot { get; set; }
        public List<string> Trope { get; set; } = new List<string>();
        public string BookLength { get; set; }

        public enum Genre
        {
            SciFi = 1, 
            Action = 2,
            Fantasy = 3,
            Mystery = 4,
            Thriller = 5,
            Romance = 6,
            Horror = 7,
            HistoricalFiction = 8,
            LiteraryFiction = 9,
            YoungAdult = 10,
            NewAdult = 11,
            NonFiction = 12,
        }
    }
}
