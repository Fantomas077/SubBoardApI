using System.Net.Http.Json;
using SubBoard.Domain.Entities;

namespace SubBoard.Blazor.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Category>>("api/category")
                   ?? new List<Category>();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Category>($"api/category/{id}");
        }

        public async Task<bool> CreateAsync(Category category)
        {
            var response = await _http.PostAsJsonAsync("api/category", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync( Category category)
        {
            var response = await _http.PutAsJsonAsync($"api/category/{category.Id}", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/category/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
