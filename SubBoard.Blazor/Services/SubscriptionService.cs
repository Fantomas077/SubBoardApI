using SubBoard.Application.Dtos.Subscription;

namespace SubBoard.Blazor.Services
{
    public class SubscriptionService
    {
        private readonly HttpClient _http;

        public SubscriptionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SubscriptionDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<SubscriptionDto>>("api/subscription")
                   ?? new List<SubscriptionDto>();
        }

        public async Task<SubscriptionDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<SubscriptionDto>($"api/subscription/{id}");
        }

        public async Task<bool> CreateAsync(CreateSubscriptionDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/subscription", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(UpdateSubscriptionDto dto)
        {
            var response = await _http.PutAsJsonAsync("api/subscription", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/subscription/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
