using BookRecommendationApp.ViewModel;
namespace BookRecommendationApp.View;

public partial class BookResultsPage : ContentPage
{
	public BookResultsViewModel ViewModel { get; }
	public BookResultsPage()
	{
		InitializeComponent();
        ViewModel = new BookResultsViewModel();
        BindingContext = ViewModel;
    }
    public BookResultsPage(BookResultsViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
        BindingContext = vm;
    }
}