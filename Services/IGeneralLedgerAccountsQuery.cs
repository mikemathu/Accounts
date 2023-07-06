using Accounts.Models;

namespace Accounts.Services
{
    public interface IGeneralLedgerAccountsQuery
    {
        Task<AccountDetail> GetAccountDetails(int accountID);
        Task<IEnumerable<AccountDetail>> GetAllAccounts();
        Task<IEnumerable<CashFlowCategory>> GetActiveCashFlowCategories();
        Task<IEnumerable<AccountClass>> GetAllAccountClasses();
        Task<IEnumerable<SubAccountDetail>> GetAllSubAccountsByAccountID(int accountID);
    }
}
