using BookRecommendationApp.Model.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookRecommendationApp.ViewModel
{
    public class BookResultsViewModel
    {
        public ObservableCollection<BookDto> Books { get; private set; } = new();
        public void SetBooks(List<BookDto> books)
        {
            Books.Clear();
            foreach (var book in books)
                Books.Add(book);
        }

    }
}
