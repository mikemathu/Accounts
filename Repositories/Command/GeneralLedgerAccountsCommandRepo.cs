using Accounts.Models;
using Accounts.Services.Command;
using Microsoft.EntityFrameworkCore;
using Accounts.Data;
using System;

namespace Accounts.Repositories.Command
{
    public class GeneralLedgerAccountsCommandRepo : IGeneralLedgerAccountsCommand
    {
        private readonly ApplicationDbContext _context;

        public GeneralLedgerAccountsCommandRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public void CreateUpdateAccount(AccountDetail account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            _context.AccountsDetails.Add(account);
        }   
        public void CreateUpdateSubAccount(SubAccountDetail subAccountModel)
        {
            if (subAccountModel == null)
            {
                throw new ArgumentNullException(nameof(subAccountModel));
            }

            _context.SubAccountsDetails.Add(subAccountModel);
        }
        public void CreateUpdateCashFlowCategory(CashFlowCategory cashFlowCategoryModel)
        {
            if (cashFlowCategoryModel == null)
            {
                throw new ArgumentNullException(nameof(cashFlowCategoryModel));
            }

            _context.CashFlowCategories.Add(cashFlowCategoryModel);
        }

        public void CreateAccountClass(AccountClass accountClass)
        {
            if (accountClass == null)
            {
                throw new ArgumentNullException(nameof(accountClass));
            }

            _context.AccountClasses.Add(accountClass);
        }

        public AccountDetail GetAccountById(int accountID)
        {
            return _context.AccountsDetails.FirstOrDefault(p => p.AccountID == accountID);
        }

       /* public SubAccountDetail GetSubAccountById(int accountID)
        {
            return _context.SubAccountsDetails.FirstOrDefault(p => p.AccountID == accountID);
        }*/
        public bool DeleteAccount(int accountID)
        {
            var account = GetSubAccountById(accountID);

            // Check if the account has associated sub-accounts
            bool hasSubAccounts = _context.SubAccountsDetails.Any(s => s.AccountID == accountID);

            if (hasSubAccounts)
            {
                return false;
            }

            _context.Remove(account);
            return true;
        }

        public SubAccountDetail GetSubAccountById(int subAccountID)
        {
            return _context.SubAccountsDetails.FirstOrDefault(p => p.SubAccountID == subAccountID);
        }
      /*  public void DeleteSubAccount(int subAccountID)
        {
            var account = GetSubAccountById(subAccountID);
            _context.Remove(account);
        }*/

        public bool DeleteSubAccount(int subAccountID)
        {
            var subAccount = GetSubAccountById(subAccountID);

            //if (subAccount != null && subAccount.CurrentBalance == 0)
            if (subAccount.CurrentBalance == 0)
            {
                _context.SubAccountsDetails.Remove(subAccount);
                return true;
            }            
            return false;
        }

        public CashFlowCategory GetCashFlowCategoryById(int cashFlowCategoryID)
        {
            return _context.CashFlowCategories.FirstOrDefault(p => p.CashFlowCategoryID == cashFlowCategoryID);
        }
        public void DeleteCashFlowCategory(int cashFlowCategoryID)
        {
            var account = GetCashFlowCategoryById(cashFlowCategoryID);
            _context.Remove(account);
        }










        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

      
    }
}
