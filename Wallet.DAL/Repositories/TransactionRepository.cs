using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.DAL.Entities;
using Wallet.DAL.EF;
using Wallet.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Wallet.DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private WalletContext db;

        public TransactionRepository(WalletContext context)
        {
            this.db = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transactions;
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public void Create(Transaction transaction)
        {
            db.Transactions.Add(transaction);
        }

        public void Update(Transaction transaction)
        {
            db.Entry(transaction).State = EntityState.Modified;
        }
        public IEnumerable<Transaction> Find(Func<Transaction, Boolean> predicate)
        {
            return null;
            //return db.Transactions.Include(o => o.SourceAccount).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction != null)
                db.Transactions.Remove(transaction);
        }
    }
}