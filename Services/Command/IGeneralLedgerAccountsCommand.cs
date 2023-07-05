using Accounts.Models;

namespace Accounts.Services.Command
{
    public interface IGeneralLedgerAccountsCommand
    {
        bool SaveChanges();
        void CreateUpdateAccount(AccountDetail account);
        void CreateAccountClass(AccountClass account);
    }
}
