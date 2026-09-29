using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookRecommendationApp.ViewModel
{
    public class GenreSubplotViewModel
    {
        private readonly CatalogService _catalogService;

        public ObservableCollection<SubplotDto> Subplots { get; } = new();

        public GenreSubplotViewModel(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task LoadSubplotsAsync(int genreId)
        {
            Subplots.Clear();

            var subplots = await _catalogService.GetGenreSubplotsAsync(genreId);

            foreach (var subplot in subplots)
            {
                Subplots.Add(subplot);
            }
        }
    }
}
