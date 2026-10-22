using BookRecommendationApp.View;
using Microsoft.Extensions.DependencyInjection;

namespace BookRecommendationApp
{
    public partial class App : Application
    {
        public App(LoginPage loginPage)
        {
            InitializeComponent();

            MainPage = new NavigationPage(loginPage);
        }
    }
}