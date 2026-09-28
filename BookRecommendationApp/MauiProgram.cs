using BookRecommendationApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using BookRecommendationApp.ViewModel;

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
            builder.Services.AddHttpClient<CatalogService>();
            builder.Services.AddTransient<RandomBookViewModel>();
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}
