using API_Client.Services;
using API_Client.Model;
namespace API_Client.Services
{
    public interface IBankTransferService
    {
        public Task<BankTransfer> GetBankTransfer(int id);
        public Task<List<BankTransfer>> GetBankTransferByIban(string iban);
        public Task<List<BankTransfer>> GetBankTransferByName(string user);

        public Task<BankTransfer> AddBankTransfer(BankTransfer bankTransfer);
        public Task<List<BankTransfer>> GetAllBankTransfer();
    }
}