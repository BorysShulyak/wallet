using Wallet.BLL.DTO;
using System.Collections.Generic;

namespace Wallet.BLL.Interfaces
{
    public interface ITransactionService
    {
        void MakeTransaction(TransactionDTO transactionDto);
        AccountDTO GetSourceAccount(int? id);
        AccountDTO GetTargetAccount(int? id);
        IEnumerable<AccountDTO> GetAccounts();
        void Dispose();
    }
}
