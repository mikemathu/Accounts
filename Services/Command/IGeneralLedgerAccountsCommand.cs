using Accounts.Models;

namespace Accounts.Services.Command
{
    public interface IGeneralLedgerAccountsCommand
    {
        bool SaveChanges();
        void CreateUpdateAccount(AccountDetail account);
        void CreateUpdateSubAccount(SubAccountDetail subAccountModel);
        void CreateUpdateCashFlowCategory(CashFlowCategory cashFlowCategoryModel);
        void CreateAccountClass(AccountClass account);
        bool DeleteAccount(int accountID);
        bool DeleteSubAccount(int subAccountID);
        void DeleteCashFlowCategory(int cashFlowCategoryID);
    }
}
