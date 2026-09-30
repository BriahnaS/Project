using BookRecommendationApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using BookRecommendationApp.ViewModel;
using BookRecommendationApp.View;

namespace BookRecommendationApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient<CatalogService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7003/api/catalog/");
            });
            builder.Services.AddTransient<RandomBookViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<GenresViewModel>();
            builder.Services.AddTransient<GenresPage>();
            builder.Services.AddTransient<TropesAndSubplotsPage>();
            builder.Services.AddTransient<TropesAndSubplotViewModel>();

            return builder.Build();
        }
    }
}
