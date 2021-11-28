using System;
namespace Wallet.WEB.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public decimal MoneySum { get; set; }

        public int SourceAccountId { get; set; }

        public int TargetAccountId { get; set; }
    }
}
