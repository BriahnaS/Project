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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is RandomBookViewModel vm)
            {

                vm.ScrollAction = async (index) =>
                {
                    await CarouselBooks.ScrollTo(index, position: ScrollToPosition.Center, animate: true);
                };
            }
        }
    }
}
