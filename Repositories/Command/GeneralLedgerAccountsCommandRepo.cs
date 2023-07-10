using Accounts.Models;
using Accounts.Services.Command;
using Microsoft.EntityFrameworkCore;
using Accounts.Data;
using System;
using System.Security.Principal;
using Accounts.Models.Payment_Modes;

namespace Accounts.Repositories.Command
{
    public class GeneralLedgerAccountsCommandRepo : IGeneralLedgerAccountsCommand
    {
        private readonly ApplicationDbContext _context;

        public GeneralLedgerAccountsCommandRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public bool CreateUpdateAccount(AccountDetail account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            try
            {
                _context.AccountsDetails.Add(account);
                return true;
            }
            catch (Exception ex)
            {
                //throw new ArgumentNullException();
                return false;
            }
        }   
        public bool CreateUpdateSubAccount(SubAccountDetail subAccountModel)
        {
     /*       if (subAccountModel == null)
            {
                throw new ArgumentNullException(nameof(subAccountModel));
            }

            _context.SubAccountsDetails.Add(subAccountModel);*/

            //
            if (subAccountModel == null)
            {
                throw new ArgumentNullException(nameof(subAccountModel));
            }
            try
            {
                _context.SubAccountsDetails.Add(subAccountModel);
                return true;
            }
            catch (Exception ex)
            {
                //throw new ArgumentNullException();
                return false;
            }
        }
        public bool CreateUpdateCashFlowCategory(CashFlowCategory cashFlowCategoryModel)
        {
      /*      if (cashFlowCategoryModel == null)
            {
                throw new ArgumentNullException(nameof(cashFlowCategoryModel));
            }

            _context.CashFlowCategories.Add(cashFlowCategoryModel);*/

            //
            if (cashFlowCategoryModel == null)
            {
                throw new ArgumentNullException(nameof(cashFlowCategoryModel));
            }
            try
            {
                _context.CashFlowCategories.Add(cashFlowCategoryModel);
                return true;
            }
            catch (Exception ex)
            {
                //throw new ArgumentNullException();
                return false;
            }
        }

        public bool CreateAccountClass(AccountClass accountClass)
        {
         /*   if (accountClass == null)
            {
                throw new ArgumentNullException(nameof(accountClass));
            }

            _context.AccountClasses.Add(accountClass);*/



            ///
            if (accountClass == null)
            {
                throw new ArgumentNullException(nameof(accountClass));
            }
            try
            {
                _context.AccountClasses.Add(accountClass);
                return true;
            }
            catch (Exception ex)
            {
                //throw new ArgumentNullException();
                return false;
            }
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
          /*  var account = GetCashFlowCategoryById(cashFlowCategoryID);
            _context.Remove(account);*/

        /*    var subAccount = GetCashFlowCategoryById(cashFlowCategoryID);

            //if (subAccount != null && subAccount.CurrentBalance == 0)
            if (subAccount.CurrentBalance == 0)
            {
                _context.SubAccountsDetails.Remove(subAccount);
                return true;
            }
            return false;*/
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public bool CreateUpdatePaymentMode(PaymentMode paymentMode)
        {
            if (paymentMode == null)
            {
                throw new ArgumentNullException(nameof(paymentMode));
            }
            try
            {
                _context.PaymentModes.Add(paymentMode);
                return true;
            }
            catch (Exception ex)
            {
                //throw new ArgumentNullException();
                return false;
            }
        }






        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        bool IGeneralLedgerAccountsCommand.DeleteCashFlowCategory(int cashFlowCategoryID)
        {
            throw new NotImplementedException();
        }
    }
}
