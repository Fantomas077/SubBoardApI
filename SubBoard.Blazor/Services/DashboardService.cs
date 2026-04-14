using System.Net.Http.Json;
using SubBoard.Application.Dtos.Dashboard;

public class DashboardService
{
    private readonly HttpClient _http;

    public DashboardService(HttpClient http)
    {
        _http = http;
    }

    public async Task<DashboardDto> GetDashboard()
    {
        return await _http.GetFromJsonAsync<DashboardDto>("api/dashboard");
    }
}
