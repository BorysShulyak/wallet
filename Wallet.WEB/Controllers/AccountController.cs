using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallet.BLL.DTO;
using Wallet.BLL.Infrastructure;
using Wallet.BLL.Interfaces;


namespace Wallet.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController: ControllerBase
    {
        ITransactionService transactionService;

        public AccountController(ITransactionService serv)
        {
            transactionService = serv;
        }

        [HttpGet]
        public IActionResult GetAcouunts()
        {
            var accounts = transactionService.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        public IActionResult MakeAccount(AccountDTO accountDTO)
        {
            try
            {
                transactionService.MakeAccount(accountDTO);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest();
            }
        }
    }
}
