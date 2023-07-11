using Accounts.Models;
using Accounts.Models.Banks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        static ApplicationDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<AccountClass> AccountClasses { get; set; }
        public DbSet<AccountDetail> AccountsDetails { get; set; }
        public DbSet<CashFlowCategory> CashFlowCategories { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<FiscalPeriod> FiscalPeriods { get; set; }
        public DbSet<JournalVoucher> JournalVouchers { get; set; }
        public DbSet<LetterCase> LetterCases { get; set; }
        public DbSet<SubAccountDetail> SubAccountsDetails { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }


        //Banks
        public DbSet<Bank> Banks { get; set; }


    }
}