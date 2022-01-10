using API_Client.Interfaces;
using API_Client.Model;
using API_Client.Repositories;

namespace API_Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }
        public async Task<Account> AddAccount(Account account)
        {
            return await accountRepository.AddAccount(account);
        }

        public  void Delete(int id)
        {
             accountRepository.DeleteAccount(id);    
        }

        public async Task<Account> GetAccount(int id)
        {
            return await accountRepository.GetAccount(id);
        }
        public async Task<Account> UpdateAmountAccount(int id, int amount,bool buy)
        {
            var oldAmountAccount = await accountRepository.GetAccount(id);
            if (buy)
                oldAmountAccount.balance -= amount;
            else
                oldAmountAccount.balance += amount;
            await accountRepository.UpdateAccount(oldAmountAccount);
            return oldAmountAccount;
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await accountRepository.AccountsList();
        }
    }
}
