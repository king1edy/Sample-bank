using SampleBankApp.Core.Service;
using SampleBankApp.Domain;

namespace WebApp.Service
{
    public class TransactionService : ITransactionService
    {
        List<Transaction> _transactions = new List<Transaction>();

        public async Task<Transaction> FundTransfer(Transaction transaction)
        {
            var response = new Transaction();

            // Get account for this transaction.
            var accountObj = AccountList();

            var acct =
                accountObj.Where(e => e.IsActive == true && e.Id == transaction.CustomerId).FirstOrDefault();
            //var accountHolder = AccountNameEnquiry(accountObj.Name);

            // Check account balance is sufficient for the transaction + charges .
            if (acct.AccountBalance >= transaction.Amount)
            {
                // send money here.
                var acctNo = new Transaction()
                {
                    Id = transaction.Id,
                    CustomerId = transaction.CustomerId,
                    Amount = transaction.Amount,
                    Charge = transaction.Amount / 100 * 2,
                    TransactionDate = transaction.TransactionDate,
                    TransactionTime = transaction.TransactionTime,
                    Narration = transaction.Narration
                };

                _transactions.Add(acctNo);

                // send money using payment-gateway here...
                response = acctNo;
            }

            // Do fund transfer here...

            return response;
        }

        public async Task<TransactionReversal> Reversal(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await Task.FromResult(_transactions);
        }

        public async Task<Account> GetAccountBalance(Guid accountId)
        {
            var response = new Account();

            // get the repository of account in the system.
            var accountsRepo = AccountList();
            // Check if account exist with given Id
            foreach (var acct in accountsRepo)
            {
                if (acct.Id == accountId)
                {
                    response.Id = acct.Id;
                    response.Name = acct.Name;
                    response.AccountNumber = acct.AccountNumber;
                    response.AccountBalance = acct.AccountBalance;
                    response.IsActive = acct.IsActive;
                    break;
                }
            }

            return await Task.FromResult(response);
        }

        public async Task<Account> AccountNameEnquiry(string AccountHolderName)
        {
            var response = new Account();

            // get the repository of account in the system.
            var accountsRepo = AccountList();
            // Check if account exist with given Id
            foreach (var acct in accountsRepo)
            {
                if (acct.Name.Equals(AccountHolderName, StringComparison.OrdinalIgnoreCase))
                {
                    response.Id = acct.Id;
                    response.Name = acct.Name;
                    response.AccountNumber = acct.AccountNumber;
                    response.AccountBalance = acct.AccountBalance;
                    response.IsActive = acct.IsActive;
                    break;
                }
            }

            return await Task.FromResult(response);
        }

        private List<Account> AccountList()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                    Name = "King Oba",
                    AccountNumber = "1234567890",
                    AccountBalance = 3000.0m,
                    IsActive = true
                },
                new Account()
                {
                    Id = Guid.Parse("cfe030a1-add2-493d-b6e0-ac4fcda228b2"),
                    Name = "Dude guy",
                    AccountNumber = "3234567850",
                    AccountBalance = 30000.0m,
                    IsActive = true
                },
                new Account()
                {
                    Name = "Eddy Murphy",
                    AccountNumber = "0454534233",
                    AccountBalance = 35000.0m,
                    IsActive = true
                },
                new Account()
                {
                    Name = "Ngozi Mba",
                    AccountNumber = "0923434344",
                    AccountBalance = 5000.0m,
                    IsActive = false
                }
            };

            return accounts;
        }
    }
}
