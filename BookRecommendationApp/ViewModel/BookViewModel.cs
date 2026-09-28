using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorsDisplay => string.Join(", ", Authors);
        public List<string> Authors { get; set; }
    }
}
