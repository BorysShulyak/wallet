using System;
namespace Wallet.DAL.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal MoneySum { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int SourceAccountId { get; set; }
        public Account SourceAccount { get; set; }

        public int TargetAccountId { get; set; }
        public Account TargetAccount { get; set; }
    }
}
