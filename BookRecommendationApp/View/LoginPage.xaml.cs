using BookRecommendationApp.ViewModel;

namespace BookRecommendationApp.View;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}