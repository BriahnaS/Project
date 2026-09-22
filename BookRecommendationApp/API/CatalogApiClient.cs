using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using BookRecommendationApp.Model.Classes;

namespace BookRecommendationApp.API
{
    public class CatalogApiClient
    {
        private readonly HttpClient _http;

        public CatalogApiClient(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://localhost:5058");
        }

        public async Task<List<Title>> GetTitlesAsync()
        {
            var response = await _http.GetAsync("api/catalog");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Title>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
