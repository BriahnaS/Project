using BookRecommendationApp.Services;
using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace BookRecommendationApp.ViewModel
{
    public class RandomBookViewModel : INotifyPropertyChanged
    {
        private readonly CatalogService _catalog;

        public Action<string, List<string>> FlipAction { get; set; }

        public ICommand AnimateRandomBookCommand { get; }

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

            AnimateRandomBookCommand = new Command(async () => await AnimateRandomBookAsync());
        }

        public async Task LoadRandomBookAsync()
        {
            RandomBook = await _catalog.GetRandomBookAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task AnimateRandomBookAsync()
        {

            for (int i= 0; i < 12; i++)
            {
                var fake = FakeBookGenerator.GetFakeBook();
                FlipAction?.Invoke(fake.Title, fake.Authors);
                await Task.Delay(80);
            }

            var realBook = await _catalog.GetRandomBookAsync();
            FlipAction?.Invoke(realBook.Title, realBook.Authors);

            RandomBook = realBook;

        }
    }
}
