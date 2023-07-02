using Accounts.Models;
using Accounts.Models.VM;

namespace Accounts.Services
{
    public interface IGeneralLedgerAccountsQuery
    {
        Task<IEnumerable<AccountDetail>> GetAllAccounts();
    }
}
