using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.Services;
using System;
using BookRecommendationApp.Model;
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

        private readonly UserSelectionState _state;
        private List<GenreDto> _selectedGenres;

        public ObservableCollection<TropeDto> Tropes { get; } = new();
        public ObservableCollection<SubplotDto> Subplots { get; } = new();

        public ObservableCollection<GenreDto> SelectedGenres { get; } = new();
        public ObservableCollection<TropeDto> SelectedTropes { get; } = new();
        public ObservableCollection<SubplotDto> SelectedSubplots { get; } = new();

        public ICommand SelectTropeCommand { get; }
        public ICommand SelectSubplotCommand { get; }

        public bool HasLoadedOnce { get; private set; }

        public TropesAndSubplotViewModel(CatalogService catalogService, UserSelectionState state)
        {
            _catalogService = catalogService;
            _state = state;
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
            HasLoadedOnce = true;

            Tropes.Clear();
            Subplots.Clear();
            SelectedTropes.Clear();
            SelectedSubplots.Clear();

            var genreIds = _selectedGenres.Select(g => g.GenreId).ToList();

            var tropes = await _catalogService.GetGenreTropesAsync(genreIds);
            var subplots = await _catalogService.GetGenreSubplotsAsync(genreIds);

            foreach (var t in tropes)
            {
                t.IsSelected = _state.SelectedTropeIds.Contains(t.TropeId);
                if (t.IsSelected)
                {
                    SelectedTropes.Add(t);
                }
                Tropes.Add(t);
            }

            foreach (var s in subplots)
            {
                s.IsSelected = _state.SelectedSubplotIds.Contains(s.SubplotId);
                if (s.IsSelected)
                {
                    SelectedSubplots.Add(s);
                }
                Subplots.Add(s);
            }
        }

        private void OnTropeSelected(TropeDto trope)
        {
            if (trope == null)
                return;

            trope.IsSelected = !trope.IsSelected;

            if (trope.IsSelected)
            {
                if (!SelectedTropes.Contains(trope))
                {
                    SelectedTropes.Add(trope);
                }

                if (!_state.SelectedTropeIds.Contains(trope.TropeId))
                {
                    _state.SelectedTropeIds.Add(trope.TropeId);
                }
            }
            else
            {
                SelectedTropes.Remove(trope);
                _state.SelectedTropeIds.Remove(trope.TropeId);
            }
        }

        private void OnSubplotSelected(SubplotDto subplot)
        {
            if (subplot == null)
                return;

            subplot.IsSelected = !subplot.IsSelected;

            if (subplot.IsSelected)
            {
                if (!SelectedSubplots.Contains(subplot))
                {
                    SelectedSubplots.Add(subplot);
                }
                if (!_state.SelectedSubplotIds.Contains(subplot.SubplotId))
                {
                    _state.SelectedSubplotIds.Add(subplot.SubplotId);
                }
            }
            else
            {
                SelectedSubplots.Remove(subplot);
                _state.SelectedSubplotIds.Remove(subplot.SubplotId);
            }
        }

        public void ClearSelections()
        {
            _state.SelectedTropeIds.Clear();
            _state.SelectedSubplotIds.Clear();

            foreach (var t in Tropes)
            {
                t.IsSelected = false;
            }

            foreach (var s in Subplots)
            {
                s.IsSelected = false;
            }
            SelectedTropes.Clear();
            SelectedSubplots.Clear();
        }
    }
}
