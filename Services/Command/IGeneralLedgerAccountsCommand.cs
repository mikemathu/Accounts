﻿using Accounts.Models;
using Accounts.Models.Banks;

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

        //Banks
        bool CreateUpdateBank(Bank account);
        bool DeleteBank(int bankID);
    }
}
