using Accounts.Models.VM;
using Accounts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Controllers
{
    public class AccountsController : Controller
    {
        /* public IActionResult FiscalPeriods()
         {
             return View();
         }*/
        private readonly IFiscalPeriods _fiscalperiodRepository;

        public AccountsController(IFiscalPeriods fiscalPeriodsRepository)
        {
            _fiscalperiodRepository = fiscalPeriodsRepository;
        }
        public async Task<IActionResult> FiscalPeriods()
        {
            var items = await _fiscalperiodRepository.GetFiscalPeriods();

            FiscalPeriodVMList inventoryItems = new FiscalPeriodVMList()
            {
                FiscalPeriodsList = items,
            };
            return View(inventoryItems);

            /*return NotFound();*/
        }
        public IActionResult GeneralLedgerAccounts()
        {
            return View();
        } 
        public IActionResult PaymentModes()
        {
            return View();
        }
        public IActionResult Banks()
        {
            return View();
        } 
        public IActionResult CashierShifts()
        {
            return View();
        }
        public IActionResult JournalVouchers()
        {
            return View();
        } 
        public IActionResult Taxes()
        {
            return View();
        } 
        public IActionResult CashTransfers()
        {
            return View();
        }
        public IActionResult BankDeposits()
        {
            return View();
        }
        public IActionResult Cheques()
        {
            return View();
        }
        public IActionResult BankReconciliation()
        {
            return View();
        } 
        public IActionResult CurrencyUnit()
        {
            return View();
        }
        public IActionResult FixedAssetManagement()
        {
            return View();
        } 
        public IActionResult Budgeting()
        {
            return View();
        }
        public IActionResult Capitations()
        {
            return View();
        } 
        public IActionResult OpeningBalances()
        {
            return View();
        }
    }
}
