using API_Client.Model;
using API_Client.Services;
namespace API_Client.Interfaces
{
    public interface IAccountService
    {
        public void Delete(int id);
        public Task<Account> AddAccount(Account bankTransfer);
        public Task<Account> UpdateAmountAccount(int id, int amount, bool buy);
        public Task<Account> GetAccount(int id);
        public Task<List<Account>> GetAllAccounts();
    }
}
