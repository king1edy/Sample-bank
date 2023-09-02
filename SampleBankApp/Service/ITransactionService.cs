using SampleBankApp.Domain;

namespace SampleBankApp.Core.Service
{
    public interface ITransactionService
    {
        Task<Transaction> FundTransfer(Transaction  transaction);
        Task<TransactionReversal> Reversal(Transaction transaction);
        Task<List<Transaction>> GetAllTransactions();
        Task<AccountDto> GetAccountBalance(Guid  accountId);
        Task<AccountDto> AccountNameEnquiry(string AccountHolderName);
    }
}
