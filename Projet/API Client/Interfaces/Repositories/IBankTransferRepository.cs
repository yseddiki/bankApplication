using API_Client.Model;

namespace API_Client.Repositories
{
    public interface IBankTransferRepository
    {

        Task<List<BankTransfer>> BankTransfersList();
        Task<List<BankTransfer>> GetBankTransferByIban(string iban);
        Task<List<BankTransfer>> GetBankTransferByName(string user);
        Task<BankTransfer> AddBankTransfer(BankTransfer bankTransfer);
        Task<BankTransfer> GetBankTransfer(int id);
    }
}