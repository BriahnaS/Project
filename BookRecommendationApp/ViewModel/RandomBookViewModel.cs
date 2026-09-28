using BookRecommendationApp.Services;
using BookRecommendationApp.Model.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BookRecommendationApp.ViewModel
{
    public class RandomBookViewModel : INotifyPropertyChanged
    {
        private readonly CatalogService _catalog;
        public ICommand LoadRandomBookCommand { get; }
        private BookDto _randomBook;

        public BookDto RandomBook { get => _randomBook; 
            set
            {
                _randomBook = value;
                OnPropertyChanged();
            }
        }

        public RandomBookViewModel(CatalogService catalog)
        {
            _catalog = catalog;

            LoadRandomBookCommand = new Command(async () => await LoadRandomBookAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadRandomBookAsync()
        {
            RandomBook = await _catalog.GetRandomBookAsync();
        }
    }
}
