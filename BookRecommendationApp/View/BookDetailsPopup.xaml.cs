using BookRecommendationApp.Model.Classes;

namespace BookRecommendationApp.View;

public partial class BookDetailsPopup : ContentPage
{
    public BookDetailsPopup(BookDto book)
	{
		InitializeComponent();
        BindingContext = book;
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}