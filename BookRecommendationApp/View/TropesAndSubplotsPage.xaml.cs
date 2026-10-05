using BookRecommendationApp.Model;
using BookRecommendationApp.Services;
using BookRecommendationApp.ViewModel;
namespace BookRecommendationApp.View;

public partial class TropesAndSubplotsPage : ContentPage
{
	public TropesAndSubplotViewModel ViewModel { get; }
    private readonly IServiceProvider _serviceProvider;
    public TropesAndSubplotsPage(TropesAndSubplotViewModel vm, IServiceProvider serviceProvider)
	{
		InitializeComponent();
		ViewModel = vm;
        _serviceProvider = serviceProvider;
        BindingContext = vm;

		Loaded += async (_, _) => await vm.LoadAsync();
	}

    private async void FindBooksClicked(object sender, EventArgs e)
    {
        var catalogService = _serviceProvider.GetRequiredService<CatalogService>();

        // 2. Get the selected genres from your ViewModel
        var selectedGenres = ViewModel.SelectedGenres.Select(g => g.GenreId).ToList();

        var selectedTropes = ViewModel.SelectedTropes.Select(t => t.TropeId).ToList();

        var selectedSubplots = ViewModel.SelectedSubplots.Select(s => s.SubplotId).ToList();

        // 3. Call the API
        var request = new BookSearchRequest
        {
            GenreIds = selectedGenres,
            Tropes = selectedTropes,
            Subplots = selectedSubplots
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