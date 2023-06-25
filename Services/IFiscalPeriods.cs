using Accounts.Models.VM;

namespace Accounts.Services
{
    public interface IFiscalPeriods
    {
        Task<IEnumerable<FiscalPeriodVM>> GetFiscalPeriods();
    }
}
