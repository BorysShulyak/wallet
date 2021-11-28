﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.DAL.Entities;
using Wallet.DAL.EF;
using Wallet.DAL.Interfaces;
using System.Data.Entity;

namespace Wallet.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private WalletContext db;

        public AccountRepository(WalletContext context)
        {
            this.db = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return db.Accounts;
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public void Create(Account account)
        {
            db.Accounts.Add(account);
        }

        public void Update(Account account)
        {
            db.Entry(account).State = EntityState.Modified;
        }

        public IEnumerable<Account> Find(Func<Account, Boolean> predicate)
        {
            return db.Accounts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Account account = db.Accounts.Find(id);
            if (account != null)
                db.Accounts.Remove(account);
        }
    }
}