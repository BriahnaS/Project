using System;
using System.Collections.Generic;
using System.Text;

namespace BookRecommendationApp.Model.Login
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
