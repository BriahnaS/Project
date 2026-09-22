using BookRecommendationApp.ViewModel;

namespace BookRecommendationApp.View;

public partial class CatalogPage : ContentPage
{
	public CatalogPage(CatalogViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}