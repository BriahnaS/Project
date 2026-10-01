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
    public class TropesAndSubplotViewModel : INotifyPropertyChanged
    {
        private readonly CatalogService _catalogService;
        private List<GenreDto> _selectedGenres;

        public ObservableCollection<TropeDto> Tropes { get; } = new();
        public ObservableCollection<SubplotDto> Subplots { get; } = new();


        public ObservableCollection<TropeDto> SelectedTropes { get; } = new();
        public ObservableCollection<SubplotDto> SelectedSubplots { get; } = new();

        public ICommand SelectTropeCommand { get; }
        public ICommand SelectSubplotCommand { get; }

        public TropesAndSubplotViewModel(CatalogService catalogService)
        {
            _catalogService = catalogService;
            SelectTropeCommand = new Command<TropeDto>(OnTropeSelected);
            SelectSubplotCommand = new Command<SubplotDto>(OnSubplotSelected);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetSelectedGenres(List<GenreDto> genres)
        {
            _selectedGenres = genres;
        }

        public async Task LoadAsync()
        {
            var genreIds = _selectedGenres.Select(g => g.GenreId).ToList();

            Tropes.Clear();
            Subplots.Clear();

            var tropes = await _catalogService.GetGenreTropesAsync(genreIds);
            var subplots = await _catalogService.GetGenreSubplotsAsync(genreIds);

            foreach (var t in tropes)
                Tropes.Add(t);

            foreach (var s in subplots)
                Subplots.Add(s);
        }

        private void OnTropeSelected(TropeDto trope)
        {
            trope.IsSelected = !trope.IsSelected;

            if (trope.IsSelected)
                SelectedTropes.Add(trope);
            else
                SelectedTropes.Remove(trope);
        }

        private void OnSubplotSelected(SubplotDto subplot)
        {
            subplot.IsSelected = !subplot.IsSelected;

            if (subplot.IsSelected)
                SelectedSubplots.Add(subplot);
            else
                SelectedSubplots.Remove(subplot);
        }
    }
}
