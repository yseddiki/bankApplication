using SuperviseurApi.Models.HelbModel;

namespace SuperviseurApi.Services.HelbService
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Account> AddAccount(Account account)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/create", account);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Account>();
        }

        public async void Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Account/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Account> GetAccount(int id)
        {
            var response = await _httpClient.GetAsync($"Account/get/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Account?>();
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            var response = await _httpClient.GetAsync("Account/list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Account>?>();
        }
    }
}
