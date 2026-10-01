using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.Model
{
    public class BookSearchRequest
    {
        public List<int> GenreIds { get; set; }
        public List <int> Tropes { get; set; }
        public List<int> Subplots { get; set; }
    }
}
