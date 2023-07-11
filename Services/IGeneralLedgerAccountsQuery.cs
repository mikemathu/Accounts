using Accounts.Dtos;
using Accounts.Migrations;
using Accounts.Models;
<<<<<<< HEAD
using Accounts.Models.Banks;
=======
using Accounts.Models.Payment_Modes;
>>>>>>> f04513da27eb886490b2efca930f26d1001200be

namespace Accounts.Services
{
    public interface IGeneralLedgerAccountsQuery
    {
        Task<AccountDetail> GetAccountDetails(int accountID); 
        Task<IEnumerable<AccountDetail>> GetAllAccounts(); 
        Task<IEnumerable<CashFlowCategory>> GetActiveCashFlowCategories();
        Task<IEnumerable<AccountClass>> GetAllAccountClasses();
        Task<IEnumerable<SubAccountDetail>> GetAllSubAccountsByAccountID(int accountID);
        Task<SubAccountDetail> GetSubAccountDetails(int subAccountID);
        Task<AccountDetail> GetAccountClassName(AccountDetail accountClassID);
        Task<CashFlowCategory> GetCashFlowCategoryDetails(int cashFlowCategoryID);

<<<<<<< HEAD
        //Banks
        Task<IEnumerable<Bank>> GetAllBanks();
        Task<Bank> GetBankDetails(int accountID);
=======
        //Payment Modes
        Task<IEnumerable<PaymentMode>> GetAllPaymentModes(); 

        Task<PaymentMode> GetPaymentModeDetails(int paymentModeID);
>>>>>>> f04513da27eb886490b2efca930f26d1001200be
    }
}
