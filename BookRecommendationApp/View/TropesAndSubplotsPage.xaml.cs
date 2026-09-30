using BookRecommendationApp.ViewModel;
namespace BookRecommendationApp.View;

public partial class TropesAndSubplotsPage : ContentPage
{
	public TropesAndSubplotViewModel ViewModel { get; }
	public TropesAndSubplotsPage(TropesAndSubplotViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
		BindingContext = vm;

		Loaded += async (_, _) => await vm.LoadAsync();
	}
}