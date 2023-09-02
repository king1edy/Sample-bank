using Microsoft.EntityFrameworkCore;
using SampleBankApp.Domain;

namespace SampleBankApp.Core.DBContext
{
    public class SampleBankContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SampleBankApp");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionReversal> TransactionReversals { get; set; }
    }
}
