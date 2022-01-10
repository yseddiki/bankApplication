using API_Client.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Client.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext databaseContext;
        public AccountRepository(DatabaseContext database)
        {
           databaseContext = database;
        }
        public async Task<Account> AddAccount(Account account)
        {
            await databaseContext.Accounts.AddAsync(account);
            await databaseContext.SaveChangesAsync();
            return account;
        }
        public async Task UpdateAccount(Account account)
        {
            databaseContext.Accounts.Update(account);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Account> GetAccount(int id)
        {
            return await databaseContext.Accounts.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async void DeleteAccount(int id)
        {
            var account = await GetAccount(id);
            databaseContext.Accounts.Remove(account);
            databaseContext.SaveChanges();
        }

        public async Task<List<Account>> AccountsList()
        {
            return await databaseContext.Accounts.ToListAsync();
        }
    }
}
