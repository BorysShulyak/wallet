using System;
namespace Wallet.BLL.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal MoneySum { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int SourceAccountId { get; set; }

        public int TargetAccountId { get; set; }
    }
}
