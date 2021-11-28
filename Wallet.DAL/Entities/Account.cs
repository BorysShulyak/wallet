using System.Collections.Generic;
namespace Wallet.DAL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Money { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
