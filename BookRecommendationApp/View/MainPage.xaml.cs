using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.ViewModel;
using BookRecommendationApp;
using System.Text.Json;
using BookRecommendationApp.View;

namespace BookRecommendationApp
{
    public partial class MainPage : ContentPage
    {
        public readonly GenresPage _genresPage;
        private readonly IServiceProvider _serviceProvider;
        public MainPage(RandomBookViewModel vm, GenresPage genresPage, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = vm;

            _genresPage = genresPage;
            _serviceProvider = serviceProvider;
        }

        public async void OnBuildARecClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_genresPage);
        }

        private async void OnRandomBookClicked(object sender, EventArgs e)
        {
            var page = _serviceProvider.GetRequiredService<RandomBookPage>();
            await Navigation.PushAsync(page);
        }
    }
}
