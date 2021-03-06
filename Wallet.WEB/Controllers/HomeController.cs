using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wallet.WEB.Models;
using Wallet.BLL.Interfaces;
using Wallet.BLL.DTO;
using Wallet.BLL.Infrastructure;
using AutoMapper;

namespace Wallet.WEB.Controllers
{
    public class HomeController : Controller
    {
        ITransactionService transactionService;
        public HomeController(ITransactionService serv)
        {
            transactionService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<AccountDTO> accountDtos = transactionService.GetAccounts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccountDTO, AccountViewModel>()).CreateMapper();
            var accounts = mapper.Map<IEnumerable<AccountDTO>, List<AccountViewModel>>(accountDtos);
            return View(accounts);
        }

        public ActionResult MakeAccount()
        {
            return View("MakeAccount");
        }

        [HttpPost]
        public ActionResult MakeAccount(AccountViewModel account)
        {
            try
            {
                var accountDTO = new AccountDTO
                {
                    Id = account.Id,
                    Money = account.Money
                };
                transactionService.MakeAccount(accountDTO);
                return Content("<h2>Your account was successfuly added</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(account);
        }

        public ActionResult MakeTransaction()
        {
            return View("MakeTransaction");
        }


        [HttpPost]
        public ActionResult MakeTransaction(TransactionViewModel transaction)
        {
            try
            {
                var transactionDto = new TransactionDTO {
                    SourceAccountId = transaction.SourceAccountId,
                    TargetAccountId = transaction.TargetAccountId,
                    MoneySum = transaction.MoneySum
                };
                transactionService.MakeTransaction(transactionDto);
                return Content("<h2>Your transaction was successfuly</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(transaction);
        }

        protected override void Dispose(bool disposing)
        {
            transactionService.Dispose();
            base.Dispose(disposing);
        }
    }
}
