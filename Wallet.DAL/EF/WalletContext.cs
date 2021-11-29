using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.DAL.Entities;

namespace Wallet.DAL.EF
{
    public class WalletContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=WalletDatabase.db", options =>
            {
                //options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //public WalletContext(DbContextOptions<WalletContext> options)
        //     : base(options)
        //{
        //    Database.EnsureCreated();
        //}
    }

    //public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<WalletContext>
    //{
    //    protected override void Seed(WalletContext db)
    //    {

    //        db.Accounts.Add(new Account { Money = 1000 });
    //        db.Accounts.Add(new Account { Money = 1000 });

    //        db.SaveChanges();
    //    }
    //}
}
