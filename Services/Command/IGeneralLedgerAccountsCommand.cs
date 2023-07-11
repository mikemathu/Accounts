using Accounts.Models;
<<<<<<< HEAD
using Accounts.Models.Banks;
=======
using Accounts.Models.Payment_Modes;
>>>>>>> f04513da27eb886490b2efca930f26d1001200be

namespace Accounts.Services.Command
{
    public interface IGeneralLedgerAccountsCommand
    {
        bool SaveChanges();
        bool CreateUpdateAccount(AccountDetail account); 
        bool CreateUpdateSubAccount(SubAccountDetail subAccountModel);
        bool CreateUpdateCashFlowCategory(CashFlowCategory cashFlowCategoryModel);
        bool CreateAccountClass(AccountClass account);
        bool DeleteAccount(int accountID); 
        bool DeleteSubAccount(int subAccountID);
        bool DeleteCashFlowCategory(int cashFlowCategoryID);

<<<<<<< HEAD
        //Banks
        bool CreateUpdateBank(Bank account);
        bool DeleteBank(int bankID);
=======
        //Payment Mode CreateUpdatePaymentMode
        bool CreateUpdatePaymentMode(PaymentMode account); 
        bool DeletePaymentMode(int paymentModeID);
>>>>>>> f04513da27eb886490b2efca930f26d1001200be
    }
}
