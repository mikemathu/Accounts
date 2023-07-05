using Accounts.Models;
using Accounts.Models.VM;

namespace Accounts.Services
{
    public interface IGeneralLedgerAccountsQuery
    {
        Task<AccountDetail> GetAccountDetails(int accountID);
        Task<IEnumerable<AccountDetail>> GetAllAccounts();
        Task<IEnumerable<CashFlowCategory>> GetActiveCashFlowCategories();
        Task<IEnumerable<AccountClass>> GetAllAccountClasses();
    }
}
