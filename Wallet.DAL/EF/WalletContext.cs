using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Wallet.DAL.Entities;

namespace Wallet.DAL.EF
{
    public class WalletContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        static WalletContext()
        {
            Database.SetInitializer<WalletContext>(new StoreDbInitializer());
        }
        public WalletContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<WalletContext>
    {
        protected override void Seed(WalletContext db)
        {

            db.Accounts.Add(new Account { Money = 1000 });
            db.Accounts.Add(new Account { Money = 1000 });

            db.SaveChanges();
        }
    }
}
