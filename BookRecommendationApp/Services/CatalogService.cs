using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using BookRecommendationApp.Model.Classes;

namespace BookRecommendationApp.Services
{
    public class CatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Title>> GetTitlesAsync()
        {
            var response = await _client.GetAsync("https://localhost:7003/api/catalog");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Title>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
