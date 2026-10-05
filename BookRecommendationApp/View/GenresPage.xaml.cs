using BookRecommendationApp.Services;
using BookRecommendationApp.ViewModel;
using BookRecommendationApp.Model;

namespace BookRecommendationApp.View;

public partial class GenresPage : ContentPage
{
    private readonly GenresViewModel _vm;
    private readonly IServiceProvider _serviceProvider;
    public GenresPage(GenresViewModel vm, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _vm = vm;
        _serviceProvider = serviceProvider;
        BindingContext = _vm;

        Loaded += async (_, _) =>
        {
            try
            {
                await _vm.LoadGenresAsync();
            }
            catch (HttpRequestException ex)
            {
                await DisplayAlertAsync("Network Error", "Cannot reach the server. Check your connection", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"An error occurred: {ex.Message}", "OK");
            }
        };
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<TropesAndSubplotsPage>();

        nextPage.ViewModel.SetSelectedGenres(_vm.SelectedGenres.ToList());

        await Navigation.PushAsync(nextPage);
    }

    private async void FindBooksByGenresClicked(object sender, EventArgs e)
    {
        var catalogService = _serviceProvider.GetRequiredService<CatalogService>();

        // 2. Get the selected genres from your ViewModel
        var selectedGenres = _vm.SelectedGenres.Select(g => g.GenreId).ToList();

        // 3. Call the API
        var request = new BookSearchRequest
        {
            GenreIds = selectedGenres,
            Tropes = new List<int>(), // You can fill this with selected tropes if needed
            Subplots = new List<int>() // You can fill this with selected subplots if needed
        };

        var books = await catalogService.SearchBooksAsync(request);

        // 4. Resolve the results page from DI
        var resultsPage = _serviceProvider.GetRequiredService<BookResultsPage>();

        // 5. Pass the data into the ViewModel
        resultsPage.ViewModel.SetBooks(books);

        // 6. Navigate normally
        await Navigation.PushAsync(resultsPage);
    }
}