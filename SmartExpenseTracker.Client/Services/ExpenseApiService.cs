using System.Net.Http.Json;
using SmartExpenseTracker.Shared.Dto;

namespace SmartExpenseTracker.Client.Services;

public class ExpenseApiService
{
    private readonly HttpClient _httpClient;

    public ExpenseApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ExpenseDto>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ExpenseDto>>("api/expenses") ?? [];
    }

    public async Task<ExpenseDto?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ExpenseDto>($"api/expenses/{id}");
    }
}