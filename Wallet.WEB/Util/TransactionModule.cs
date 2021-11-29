using Ninject.Modules;
using Wallet.BLL.Services;
using Wallet.BLL.Interfaces;

namespace NLayerApp.WEB.Util
{
    public class TransactionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITransactionService>().To<TransactionService>();
        }
    }
}