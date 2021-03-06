using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallet.BLL.DTO;
using Wallet.BLL.Interfaces;

namespace Wallet.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class WalletController: ControllerBase
    {
        ITransactionService transactionService;

        public WalletController(ITransactionService serv)
        {
            transactionService = serv;
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var transactions = transactionService.GetTransactions();
            return Ok(transactions);
        }

        [HttpPut]
        public IActionResult MakeTransaktion(TransactionDTO transactionDto)
        {
            transactionService.MakeTransaction(transactionDto);
            return Ok();
        }
    }
}
