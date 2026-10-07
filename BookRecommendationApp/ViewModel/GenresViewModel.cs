using BookRecommendationApp.Model;
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
    public class GenresViewModel : INotifyPropertyChanged
    {
        private readonly CatalogService _catalogService;
        public CatalogService CatalogService => _catalogService;

        private readonly UserSelectionState _state;

        public ObservableCollection<GenreDto> Genres { get; } = new();
        public ObservableCollection<GenreDto> SelectedGenres { get; } = new();
        public ICommand SelectGenreCommand { get; }

        public GenresViewModel(CatalogService catalogService, UserSelectionState state)
        {
            _catalogService = catalogService;
            _state = state;
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
                genre.IsSelected = _state.SelectedGenreIds.Contains(genre.GenreId);
                
                if (genre.IsSelected)
                {
                    SelectedGenres.Add(genre);
                }
                
                Genres.Add(genre);
            }
        }
        private void OnGenreSelected(GenreDto genre)
        {
            if (genre == null)
                return;

            genre.IsSelected = !genre.IsSelected;

            if (genre.IsSelected)
            {
                if (!SelectedGenres.Contains(genre))
                    SelectedGenres.Add(genre);

                if (!_state.SelectedGenreIds.Contains(genre.GenreId))
                    _state.SelectedGenreIds.Add(genre.GenreId);
            }
            else
            { 
                SelectedGenres.Remove(genre);
                _state.SelectedGenreIds.Remove(genre.GenreId); 
            }
        }

        public void ClearSelections()
        {
            _state.SelectedGenreIds.Clear();
        }
    }
}
