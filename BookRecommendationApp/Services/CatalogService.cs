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

        public async Task<List<GenreDto>> GetGenresAsync()
        {
            return await _client.GetFromJsonAsync<List<GenreDto>>("https://localhost:7003/api/catalog/genres");
        }

        public async Task<List<SubplotDto>> GetGenreSubplotsAsync(int genreId)
        {
            return await _client.GetFromJsonAsync<List<SubplotDto>>($"https://localhost:7003/api/catalog/genres/{genreId}/subplots");
        }

        public async Task<List<TropeDto>> GetGenreTropesAsync(int genreId)
        {
            return await _client.GetFromJsonAsync<List<TropeDto>>($"https://localhost:7003/api/catalog/genres/{genreId}/tropes");
        }
    }
}
