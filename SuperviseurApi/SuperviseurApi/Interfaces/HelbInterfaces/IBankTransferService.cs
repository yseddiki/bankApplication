using SuperviseurApi.Models.HelbModel;

namespace SuperviseurApi.Services.HelbService
{
    public interface IBankTransferService
    {
        Task<BankTransfer> AddBankTransfer(BankTransfer user);
        Task<List<BankTransfer>> GetAllBankTransfers();
        Task<List<BankTransfer>> GetBankTransferByIban(string iban);
        Task<List<BankTransfer>> GetBankTransferByName(string name);
        Task<BankTransfer> GetBankTransfer(int id);
    }
}