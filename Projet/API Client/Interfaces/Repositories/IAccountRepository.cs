using API_Client.Model;

namespace API_Client.Repositories
{
    public interface IAccountRepository
    {
        public void DeleteAccount(int id);
        public Task UpdateAccount(Account account);
        Task<Account> AddAccount(Account account);
        Task<List<Account>> AccountsList();
        Task<Account> GetAccount(int id);
    }
}