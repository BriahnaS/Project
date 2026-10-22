using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BookRecommendationApp.Services;
using CommunityToolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly MainPage _mainPage;

        public LoginViewModel(IAuthService authService, MainPage mainPage)
        {
            _authService = authService;
            _mainPage = mainPage;
        }

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [RelayCommand]
        private async Task LoginAsync()
        {
            var result = await _authService.LoginAsync(Email, Password);

            if (result?.Success == true)
            {
                Preferences.Set("UserId", result.UserId);

                Application.Current.MainPage = new NavigationPage(_mainPage);
            }
            else
            {
                ErrorMessage = "Invalid email or password.";
            }
        }
    }
}
