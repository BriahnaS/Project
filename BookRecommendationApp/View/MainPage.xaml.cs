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
        public MainPage(RandomBookViewModel vm, GenresPage genresPage)
        {
            InitializeComponent();
            BindingContext = vm;

            _genresPage = genresPage;

            vm.FlipAction = async (title, authors) =>
            {
                await FlipAsync(title, authors);
            };
        }
        private async Task FlipAsync(string title, List<string> authors)
        {
            await FlipCard.ScaleXToAsync(0, 100, Easing.CubicIn);


            FlipTitle.Text = title;
            FlipAuthor.Text = string.Join(", ",authors);

            await FlipCard.ScaleXToAsync(1, 100, Easing.CubicOut);
        }
        public async void OnBuildARecClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_genresPage);
        }
    }
}
