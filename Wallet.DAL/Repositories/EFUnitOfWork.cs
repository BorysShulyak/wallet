using System;
using Wallet.DAL.EF;
using Wallet.DAL.Interfaces;
using Wallet.DAL.Entities;

namespace Wallet.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WalletContext db;
        private AccountRepository accountRepository;
        private TransactionRepository transactionRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new WalletContext(connectionString);
        }
        public IRepository<Account> Accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(db);
                return accountRepository;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (transactionRepository == null)
                    transactionRepository = new TransactionRepository(db);
                return transactionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}