using RaftLabsSolution.ExternalUserService.Interfaces;
using RaftLabsSolution.ExternalUserService.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace RaftLabsSolution.ExternalUserService.Clients
{
    public class ReqResApiClient(HttpClient httpClient) : IReqResApiClient
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"users/{userId}");
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        return null;

                    throw new HttpRequestException($"API returned error: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var dataJson = doc.RootElement.GetProperty("data").GetRawText();

                return JsonSerializer.Deserialize<UserDto>(dataJson);
            }
            catch (Exception ex)
            {
                throw;
            }          
        }


        public async Task<UserListDto> GetUsersByPageAsync(int pageNumber)
        {
            try
            {
                var response = await _httpClient.GetAsync($"users?page={pageNumber}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"API returned error: {response.StatusCode} for page {pageNumber}");
                }

                var result = await response.Content.ReadFromJsonAsync<UserListDto>();

                if (result == null)
                {
                    throw new Exception("API returned empty or invalid data.");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;          
            }
        }

    }
}
