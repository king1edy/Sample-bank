using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBankApp.Domain;

namespace SampleBankApp.Core.Service
{
    public interface IAccountService
    {
        Task<Account> GetAccount(Guid Id);
        Task<List<Account>> GetAllAccount();
        Task<Account> CreateAccount(Account account);
        Task<string> DeleteAccount(Guid Id);
    }
}
