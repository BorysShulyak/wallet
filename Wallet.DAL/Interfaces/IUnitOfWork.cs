using System;
using Wallet.DAL.Entities;

namespace Wallet.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Account> Accounts { get; }
        IRepository<Transaction> Transactions { get; }

        void Save();
    }
}
