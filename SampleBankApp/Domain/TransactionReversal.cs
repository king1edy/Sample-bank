using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SampleBankApp.Domain
{
    public class TransactionReversal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public decimal TransactionAmount { get; set; }
        public DateTime ReversalDate { get; set; }
        public TimeSpan ReversalTime { get; set; }

        public Guid TransactionId { get; set; }
    }
}
