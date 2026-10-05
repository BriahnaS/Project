using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BookRecommendationApp.Model;
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
            try
            {
                var response = await _client.GetAsync("genres");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error fetching genres: {response.StatusCode}.");

                return await response.Content.ReadFromJsonAsync<List<GenreDto>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetGenresAsync failed: {ex.Message}");

                throw;
            }   
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

        public async Task<List<BookDto>> SearchBooksAsync(BookSearchRequest request)
        {
            var response = await _client.PostAsJsonAsync("search", request);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error searching books: {response.StatusCode}. Response body: {body}");
            }

            return await response.Content.ReadFromJsonAsync<List<BookDto>>();
        }
    }
}
