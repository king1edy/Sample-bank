using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBankApp.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Narration { get; set; }
        public Guid CustomerId { get; set; }
        public Decimal Amount { get; set; }
        public decimal Charge { get; set; }
        public DateTime TransactionDate { get; set; }
        public TimeSpan? TransactionTime { get; set; }
        public bool IsProccessed { get; set; }
    }
}
