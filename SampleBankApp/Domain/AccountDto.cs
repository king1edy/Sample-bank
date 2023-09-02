using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBankApp.Domain
{
    public class AccountDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string?  Name { get; set; }
        public string? AccountNumber { get; set; }
        public string? Email { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
