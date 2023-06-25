using Accounts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Procurement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }   
     
        public DbSet<FiscalPeriod> fiscalperiods { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<SubAccountDetail> SubAccountDetails { get; set; }
        public DbSet<JournalVoucher> JournalVouchers { get; set; }

    }
}