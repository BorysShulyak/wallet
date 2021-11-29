using System;
using Wallet.BLL.DTO;
using Wallet.BLL.BusinessModels;
using Wallet.DAL.Entities;
using Wallet.DAL.Interfaces;
using Wallet.BLL.Infrastructure;
using Wallet.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace Wallet.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork Database { get; set; }

        public TransactionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeTransaction(TransactionDTO transactionDto)
        {
            Account sourceAccount = Database.Accounts.Get(transactionDto.SourceAccountId);
            Account targetAccount = Database.Accounts.Get(transactionDto.TargetAccountId);

            // validation
            if (sourceAccount == null)
                throw new ValidationException("Source account was not found", "");
            if (targetAccount == null)
                throw new ValidationException("Target account was not found", "");

            // Use cashback
            decimal sum = new Cashback(0.1m).GetCashaback(transactionDto.MoneySum);

            Transaction transaction = new Transaction
            {
                //SourceAccountId = sourceAccount.Id,
                //TargetAccountId = targetAccount.Id,
                MoneySum = sum,
                Description = transactionDto.Description,
                Date = DateTime.Now,
            };
            Database.Transactions.Create(transaction);
            Database.Save();
        }

        public IEnumerable<AccountDTO> GetAccounts()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Account>, List<AccountDTO>>(Database.Accounts.GetAll());
        }

        public AccountDTO GetSourceAccount(int? id)
        {
            if (id == null)
                throw new ValidationException("Unknown id", "");
            var account = Database.Accounts.Get(id.Value);
            if (account == null)
                throw new ValidationException("Account was not found", "");

            return new AccountDTO { Money = account.Money };
        }

        public AccountDTO GetTargetAccount(int? id)
        {
            if (id == null)
                throw new ValidationException("Unknown id", "");
            var account = Database.Accounts.Get(id.Value);
            if (account == null)
                throw new ValidationException("Account was not found", "");

            return new AccountDTO { Money = account.Money };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}