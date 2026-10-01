using BookRecommendationApp.ViewModel;
namespace BookRecommendationApp.View;

public partial class BookResultsPage : ContentPage
{
	public BookResultsViewModel ViewModel { get; }
    public BookResultsPage(BookResultsViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
        BindingContext = vm;
    }
}