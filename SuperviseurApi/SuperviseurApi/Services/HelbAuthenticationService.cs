using Microsoft.Extensions.Caching.Memory;
using SuperviseurApi.Models;
using SuperviseurApi.Models.HelbModel;

namespace SuperviseurApi.Services
{
    public class HelbAuthenticationService : IHelbAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        public HelbAuthenticationService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }
        public async Task<string?> RetrieveToken(UserLogin userLogin)
        {
            var inscriptionDateTime = DateTime.UtcNow.AddMinutes(60); // refresh...
            if (!_memoryCache.TryGetValue("Token", out string? token))
            {
                var response = await _httpClient.PostAsJsonAsync("Auth/login", new { userLogin.Username , userLogin.Password});
                response.EnsureSuccessStatusCode();
                var authResponse = await response.Content.ReadFromJsonAsync<AuthentificationResponse>();
                token = authResponse?.Token;
                _memoryCache.Set("Token", token, new DateTimeOffset(inscriptionDateTime));
            }
            return token;
        }
    }
}
