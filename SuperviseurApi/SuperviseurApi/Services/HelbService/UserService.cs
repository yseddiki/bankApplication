using SuperviseurApi.Models;

namespace SuperviseurApi.Services.HelbService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User?> AddUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("User/create", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async void DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"User/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<User>?> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("User/list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<User>>();
        }

        public async Task<User> GetUser(int id)
        {
            var response = await _httpClient.GetAsync($"User/get/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User?>();
        }
    }
}
