using SuperviseurApi.Models.HelbModel;

namespace SuperviseurApi.Services.HelbService
{
    public class BankTransferService : IBankTransferService
    {
        private readonly HttpClient _httpClient;

        public BankTransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BankTransfer?> AddBankTransfer(BankTransfer user)
        {
            var response = await _httpClient.PostAsJsonAsync("BankTransfer/create", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BankTransfer>();
        }
        public async Task<List<BankTransfer>?> GetAllBankTransfers()
        {
            var response = await _httpClient.GetAsync("BankTransfer/list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BankTransfer>>();
        }
        public async Task<List<BankTransfer>> GetBankTransferByIban(string iban)
        {
            var response = await _httpClient.GetAsync($"BankTransfer/IbanList/{iban}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BankTransfer>>();
        }
        public async Task<List<BankTransfer>> GetBankTransferByName(string name)
        {
            var response = await _httpClient.GetAsync($"BankTransfer/nameList/{name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BankTransfer>>();
        }

        public async Task<BankTransfer> GetBankTransfer(int id)
        {
            var response = await _httpClient.GetAsync($"BankTransfer/get/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BankTransfer?>();
        }
    }
}
