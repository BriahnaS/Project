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

        public ObservableCollection<Title> Titles { get; set; } = new();

        public CatalogViewModel(CatalogService api)
        {
            _api = api;
            LoadTitles();
        }

        private async void LoadTitles()
        {
            var titles = await _api.GetTitlesAsync();
            Titles.Clear();

            foreach (var t in titles)
                Titles.Add(t);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
