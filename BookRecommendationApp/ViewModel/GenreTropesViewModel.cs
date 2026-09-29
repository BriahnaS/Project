using BookRecommendationApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BookRecommendationApp.Model.Classes;

namespace BookRecommendationApp.ViewModel
{
    public class GenreTropesViewModel
    {
        private readonly CatalogService _catalogService;

        public ObservableCollection<TropeDto> Tropes { get; } = new();

        public GenreTropesViewModel(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task LoadTropesAsync(int genreId)
        {
            Tropes.Clear();

            var tropes = await _catalogService.GetGenreTropesAsync(genreId);

            foreach (var trope in tropes)
            {
                Tropes.Add(trope);
            }
        }
    }
}
