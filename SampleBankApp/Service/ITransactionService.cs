using SampleBankApp.Domain;

namespace SampleBankApp.Core.Service
{
    public interface ITransactionService
    {
        Task<Transaction> FundTransfer(Transaction  transaction);
        Task<TransactionReversal> Reversal(Transaction transaction);
        Task<List<Transaction>> GetAllTransactions();
        Task<Account> GetAccountBalance(Guid  accountId);
        Task<Account> AccountNameEnquiry(string AccountHolderName);
    }
}
