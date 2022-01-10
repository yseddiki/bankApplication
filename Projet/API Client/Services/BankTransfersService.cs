using API_Client.Interfaces;
using API_Client.Model;
using API_Client.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_Client.Services
{
    public class BankTransfersService : IBankTransferService
    {
        private readonly IBankTransferRepository _bankTransferRepository;
        private readonly IAccountService _accountService;
        public BankTransfersService(IBankTransferRepository bankTransferRepository, IAccountService accountService)
        {

            _bankTransferRepository = bankTransferRepository;
            _accountService = accountService;
        }

        public async Task<BankTransfer> AddBankTransfer(BankTransfer bankTransfer)
        {
            ///Expiditor 
            await _accountService.UpdateAmountAccount(bankTransfer.ExpeditorAccountId, bankTransfer.Amount, true);
            ///Receiver
            await _accountService.UpdateAmountAccount(bankTransfer.ReceiverAccountId, bankTransfer.Amount, false);
            return await _bankTransferRepository.AddBankTransfer(bankTransfer);

        }
        public async Task<List<BankTransfer>> GetAllBankTransfer()
        {
             return await _bankTransferRepository.BankTransfersList();
        }
        public async Task<BankTransfer> GetBankTransfer(int id)
        {
            return (await _bankTransferRepository.BankTransfersList()).FirstOrDefault(x => x.Id == id); 
        } 
        public async Task<List<BankTransfer>> GetBankTransferByIban(string Iban)
        {
            return (await _bankTransferRepository.GetBankTransferByIban(Iban)); 
        }
        public async Task<List<BankTransfer>> GetBankTransferByName(string user)
        {
            return (await _bankTransferRepository.GetBankTransferByName(user));
        }
    }
}
