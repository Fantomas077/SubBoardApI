using System.Net.Http.Json;
using SubBoard.Application.Dtos.Category;

namespace SubBoard.Blazor.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<CategoryDto>>("api/category")
                   ?? new List<CategoryDto>();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<CategoryDto>($"api/category/{id}");
        }

        public async Task<bool> CreateAsync(CreateCategoryDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/category", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(UpdateCategoryDto dto)
        {
            var response = await _http.PutAsJsonAsync("api/category", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/category/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
