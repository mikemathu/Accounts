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
        public void DeleteAccount(int accountID)
        {
            var account = GetAccountById(accountID);
            _context.Remove(account);
        }

        public SubAccountDetail GetSubAccountById(int subAccountID)
        {
            return _context.SubAccountsDetails.FirstOrDefault(p => p.SubAccountID == subAccountID);
        }
        public void DeleteSubAccount(int subAccountID)
        {
            var account = GetSubAccountById(subAccountID);
            _context.Remove(account);
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
