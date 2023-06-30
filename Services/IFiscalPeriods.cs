using Accounts.Models.VM;

namespace Accounts.Services
{
    public interface IFiscalPeriods
    {

        Task<IEnumerable<FiscalPeriodVM>> GetFiscalPeriods();

        Task<IEnumerable<AccountDetailVM>> GetAccountsDetails();
        Task<IEnumerable<SubAccountDetailVM>> GetSubAccountsDetails();
    }
}
