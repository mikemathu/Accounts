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

        public void CreateAccountClass(AccountClass accountClass)
        {
            if (accountClass == null)
            {
                throw new ArgumentNullException(nameof(accountClass));
            }

            _context.AccountClasses.Add(accountClass);
        }

        public void DeleteAccount(int accountID)
        {
            var account = GetAccountById(accountID);
            _context.Remove(account);
        }
        public AccountDetail GetAccountById(int accountID)
        {
            return  _context.AccountsDetails.FirstOrDefault(p => p.AccountID == accountID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

       
    }
}
