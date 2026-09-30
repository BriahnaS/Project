using BookRecommendationApp.ViewModel;
using BookRecommendationApp.View;

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

		Loaded += async (_, _) => await _vm.LoadGenresAsync();
	}

    private async void OnNextClicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<TropesAndSubplotsPage>();

		nextPage.ViewModel.SetSelectedGenres(_vm.SelectedGenres.ToList());

        await Navigation.PushAsync(nextPage);
    }
}