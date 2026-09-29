using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace BookRecommendationApp.ViewModel
{
    public class GenreSelectionViewModel : INotifyPropertyChanged
    {
        private readonly CatalogService _catalogService;

        public ObservableCollection<GenreDto> Genres { get; } = new();
        public ObservableCollection<GenreDto> SelectedGenres { get; } = new();
        public ICommand SelectGenreCommand { get; }

        public GenreSelectionViewModel(CatalogService catalogService)
        {
            _catalogService = catalogService;
            SelectGenreCommand = new Command<GenreDto>(OnGenreSelected);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadGenresAsync()
        {
            Genres.Clear();

            var genres = await _catalogService.GetGenresAsync();

            foreach (var genre in genres)
            {
                Genres.Add(genre);
            }
        }

        private void OnGenreSelected(GenreDto genre)
        {
            if (SelectedGenres.Contains(genre))
                SelectedGenres.Remove(genre);
            else
                SelectedGenres.Add(genre);
        }
    }
}
