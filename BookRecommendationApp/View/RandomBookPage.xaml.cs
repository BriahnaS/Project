using BookRecommendationApp.ViewModel;
using BookRecommendationApp.Model;

namespace BookRecommendationApp.View;

public partial class RandomBookPage : ContentPage
{
	public RandomBookViewModel ViewModel { get; }

	public RandomBookPage(RandomBookViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
        BindingContext = vm;

		Loaded += async (_, _) =>
		{
			await ViewModel.LoadRandomBookAsync();
			await FlipAsync(ViewModel.RandomBook.Title, ViewModel.RandomBook.Authors, ViewModel.RandomBook.CoverImageUrl);
		};
    }

    private async Task FlipAsync(string title, List<string> authors, string coverUrl)
    {
        await FlipCard.ScaleXToAsync(0, 100, Easing.CubicIn);


        FlipTitle.Text = title;
        FlipAuthor.Text = string.Join(", ", authors);
        FlipCover.Source = coverUrl;

		FlipCover.Opacity = 0;
		FlipCover.FadeToAsync(1, 250);

        await FlipCard.ScaleXToAsync(1, 100, Easing.CubicOut);
    }

    private async Task AnimateFlipCard()
	{
		FlipCard.Scale = 0;
		FlipCard.Opacity = 0;

		await FlipCard.ScaleTo(1, 400, Easing.SpringOut);
		await FlipCard.FadeTo(1, 300);
    }
}