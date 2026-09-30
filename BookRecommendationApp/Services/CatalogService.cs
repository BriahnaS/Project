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
            return await _client.GetFromJsonAsync<List<BookDto>>("books");
        }

        public async Task<BookDto> GetRandomBookAsync()
        {
            return await _client.GetFromJsonAsync<BookDto>("random");
        }

        public async Task<List<GenreDto>> GetGenresAsync()
        {
            return await _client.GetFromJsonAsync<List<GenreDto>>("genres");
        }

        public async Task<List<SubplotDto>> GetGenreSubplotsAsync(List<int> genreIds)
        {
            var response = await _client.PostAsJsonAsync("genres/subplots", genreIds);
            return await response.Content.ReadFromJsonAsync<List<SubplotDto>>();
        }

        public async Task<List<TropeDto>> GetGenreTropesAsync(List<int> genreIds)
        {
            var response = await _client.PostAsJsonAsync("genres/tropes", genreIds);
            return await response.Content.ReadFromJsonAsync<List<TropeDto>>();
        }
    }
}
