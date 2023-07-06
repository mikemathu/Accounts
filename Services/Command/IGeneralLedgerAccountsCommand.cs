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
        void DeleteAccount(int accountID);
        void DeleteSubAccount(int subAccountID);
        void DeleteCashFlowCategory(int cashFlowCategoryID);
    }
}
