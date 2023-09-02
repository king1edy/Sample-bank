using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBankApp.Core.DBContext;
using SampleBankApp.Domain;

namespace SampleBankApp.Core.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        public AccountRepository()
        {
            using (var context = new SampleBankContext())
            {
                var accounts = AccountList();

                context.Accounts.AddRange(accounts);
                context.SaveChanges();
            }
        }

        public Account GetById(Guid id)
        {
            using (var context = new SampleBankContext())
            {
                var account = context.Accounts.FirstOrDefault(a => a.Id == id);
                return account;
            }
        }

        public List<Account> GetAll()
        {
            using (var context = new SampleBankContext())
            {
                var list = context.Accounts.ToList();
                return list;
            }
        }

        public Account Save(Account entity)
        {
            using (var context = new SampleBankContext())
            {
                var obj = context.Accounts.Add(entity);
                return entity;
            }
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
