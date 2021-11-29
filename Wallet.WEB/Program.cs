using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wallet.DAL.EF;
using Wallet.DAL.Entities;

namespace Wallet.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dbName = "WalletDatabase.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }
            using (var dbContext = new WalletContext())
            {
                //Ensure database is created
                dbContext.Database.EnsureCreated();
                if (!dbContext.Accounts.Any())
                {
                    dbContext.Accounts.AddRange(new Account[]
                        {
                             new Account{ Money = 1000 },
                             new Account{ Money = 1000 }
                        });
                    dbContext.SaveChanges();
                }
                foreach (var account in dbContext.Accounts)
                {
                    Console.WriteLine($"account={account.Id}");
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
