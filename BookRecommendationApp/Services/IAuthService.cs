using System;
using System.Collections.Generic;
using System.Text;
using BookRecommendationApp.Model.Login;

namespace BookRecommendationApp.Services
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(string email, string password);
    }
}
