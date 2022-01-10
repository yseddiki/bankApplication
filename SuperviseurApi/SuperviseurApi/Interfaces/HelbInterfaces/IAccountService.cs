using SuperviseurApi.Models.HelbModel;

namespace SuperviseurApi.Services.HelbService
{
    public interface IAccountService
    {
        Task<Account> AddAccount(Account account);
        void Delete(int id);
        Task<Account> GetAccount(int id);
        Task<List<Account>> GetAllAccounts();
    }
}