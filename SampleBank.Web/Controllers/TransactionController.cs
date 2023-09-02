using Microsoft.AspNetCore.Mvc;
using SampleBankApp.Core.Service;
using SampleBankApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleBank.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> loger, ITransactionService transactionService)
        {
            _logger = loger;
            _transactionService = transactionService;
        }

            // GET: api/<TransactionController>
        [HttpGet("get-transactions")]
        public async Task<IActionResult> GetTansactions()
        {
            var transactions = await _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransactionController>
        [HttpPost("transfer-fund")]
        public async Task<IActionResult> FundTransfer([FromBody] Transaction request)
        {
            var response = await _transactionService.FundTransfer(request);
            return Ok(response);
        }

        // GET api/<TransactionController>
        [HttpGet("name-enquiry")]
        public async Task<IActionResult> NameEnquiry([FromBody] string AccountName)
        {
            var response = await _transactionService.AccountNameEnquiry(AccountName);
            return Ok(response);
        }
        
    }
}
