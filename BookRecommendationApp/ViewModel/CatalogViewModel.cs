using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BookRecommendationApp.Services;
using System.Collections.ObjectModel;
using BookRecommendationApp.Model.Classes;

namespace BookRecommendationApp.ViewModel
{
    public class CatalogViewModel : INotifyPropertyChanged
    {
        private readonly CatalogService _api;

        public ObservableCollection<BookDto> Books { get; set; } = new();

        public CatalogViewModel(CatalogService api)
        {
            _api = api;
            LoadBooks();
        }

        private async void LoadBooks()
        {
            var books = await _api.GetBooksAsync();
            Books.Clear();

            foreach (var b in books)
                Books.Add(b);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
