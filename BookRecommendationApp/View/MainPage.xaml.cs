using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.ViewModel;
using System.Text.Json;

namespace BookRecommendationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(RandomBookViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
