using BookRecommendationApp.ViewModel;
using BookRecommendationApp.Model;
using BookRecommendationApp.Services;
namespace BookRecommendationApp.View;

public partial class BookResultsPage : ContentPage
{
    private readonly UserSelectionState _state;
    public BookResultsViewModel ViewModel { get; }
    private readonly IServiceProvider _serviceProvider;

    public BookResultsPage(BookResultsViewModel vm, UserSelectionState state, IServiceProvider serviceProvider)
	{
		InitializeComponent();
		ViewModel = vm;
        _state = state;
        _serviceProvider = serviceProvider;

        BindingContext = vm;
    }

    private void OnStartOverClicked(object sender, EventArgs e)
    {
        _state.ClearSelections();

        Navigation.PopToRootAsync();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var catalogService = _serviceProvider.GetRequiredService<CatalogService>();

        var request = new BookSearchRequest
        {
            GenreIds = _state.SelectedGenreIds.ToList(),
            Tropes = _state.SelectedTropeIds.ToList(),
            Subplots = _state.SelectedSubplotIds.ToList()
        };

        RefreshResults(request);
    }

    private async void RefreshResults(BookSearchRequest request)
    {
        var catalogService = _serviceProvider.GetRequiredService<CatalogService>();
        var books = await catalogService.SearchBooksAsync(request);
        ViewModel.SetBooks(books);
    }
}