using API_Client.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Client.Repositories
{
    public class BankTransferRepository : IBankTransferRepository
    {
        private readonly DatabaseContext databaseContext;

        public BankTransferRepository(DatabaseContext database)
        {
            databaseContext = database;
        }

        public async Task<BankTransfer> AddBankTransfer(BankTransfer bankTransfer)
        {
             await databaseContext.BankTransfers.AddAsync(bankTransfer);
             await databaseContext.SaveChangesAsync();  
            return bankTransfer;
        }

        public async Task<List<BankTransfer>> GetBankTransferByIban(string iban)
        {
            return await databaseContext.BankTransfers.Where(o => o.ExpeditorAccount.IBAN.StartsWith(iban) || o.ReceiverAccount.IBAN.StartsWith(iban)).ToListAsync();
        }
        public async Task<List<BankTransfer>> GetBankTransferByName(string user)
        {
            return await databaseContext.BankTransfers.Where(o => o.ExpeditorAccount.User.username.Contains(user) || o.ReceiverAccount.User.username.Contains(user)).ToListAsync();
        }


        public async Task<BankTransfer> GetBankTransfer(int id)
        {
           return await databaseContext.BankTransfers.FirstOrDefaultAsync(o=> o.Id == id);
        }

        public async Task<List<BankTransfer>> BankTransfersList()
        {
            return await databaseContext.BankTransfers.ToListAsync();
        }

    }
}
