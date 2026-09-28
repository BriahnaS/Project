using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BookRecommendationApp.Model.Classes;
using BookRecommendationApp.ViewModel;

namespace BookRecommendationApp.Services
{
    public class CatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            return await _client.GetFromJsonAsync<List<BookDto>>("https://localhost:7003/api/catalog");
        }

        public async Task<BookDto> GetRandomBookAsync()
        {
            return await _client.GetFromJsonAsync<BookDto>("https://localhost:7003/api/catalog/random");
        }
    }
}
