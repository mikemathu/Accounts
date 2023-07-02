using Accounts.Models;
using Accounts.Models.VM;
using Accounts.Services.Command;
using Microsoft.EntityFrameworkCore;
using Procurement.Data;

namespace Accounts.Repositories.Command
{
    public class FiscalCommandRepo : IFiscalPeriodCommands
    {
        private readonly ApplicationDbContext _context;

        public FiscalCommandRepo(ApplicationDbContext context)
        {
            _context = context;
        }     

        public void AddFiscalPeriod(FiscalPeriod fiscalId)
        {
            if (fiscalId == null)
            {
                throw new ArgumentNullException(nameof(fiscalId));
            }

            _context.FiscalPeriods.Add(fiscalId);
        }

        public void AddAccountDetails(AccountDetail accountDetail)
        {
            if (accountDetail == null)
            {
                throw new ArgumentNullException(nameof(accountDetail));
            }

            _context.AccountsDetails.Add(accountDetail);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
