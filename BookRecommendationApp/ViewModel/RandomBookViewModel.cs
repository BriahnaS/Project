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

        public ObservableCollection<BookDto> CarouselBooks { get; } = new();
        public Action<int> ScrollAction { get; set; } // delegate so the VM can trigger UI scrolling

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task AnimateRandomBookAsync()
        {
            CarouselBooks.Clear();

            for (int i= 0; i < 12; i++)
            {
                CarouselBooks.Add(FakeBookGenerator.GetFakeBook());
            }

            for (int i=0; i < CarouselBooks.Count; i++)
            {
                ScrollAction?.Invoke(i);
                await Task.Delay(80);
            }

            var realBook = await _catalog.GetRandomBookAsync();

            CarouselBooks.Add(realBook);

            ScrollAction?.Invoke(CarouselBooks.Count - 1);
        }
    }
}
