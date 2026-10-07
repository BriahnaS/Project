using BookRecommendationApp.ViewModel;
using BookRecommendationApp.Model;
namespace BookRecommendationApp.View;

public partial class BookResultsPage : ContentPage
{
    private readonly UserSelectionState _state;
    public BookResultsViewModel ViewModel { get; }
    private readonly GenresViewModel _genresViewModel;
    private readonly TropesAndSubplotViewModel _tropesAndSubplotViewModel;
    public BookResultsPage()
	{
		InitializeComponent();
        ViewModel = new BookResultsViewModel();
        BindingContext = ViewModel;
    }
    public BookResultsPage(BookResultsViewModel vm, GenresViewModel genresVm, TropesAndSubplotViewModel tropesAndSubplotVm, UserSelectionState state)
	{
		InitializeComponent();
		ViewModel = vm;
        _genresViewModel = genresVm;
        _tropesAndSubplotViewModel = tropesAndSubplotVm;
        _state = state;

        BindingContext = vm;
    }

    private void OnStartOverClicked(object sender, EventArgs e)
    {
        _state.ClearSelections();

        Navigation.PopToRootAsync();
    }

}