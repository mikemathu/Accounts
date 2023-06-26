﻿using Accounts.Models.VM;
using Accounts.Services;
using Accounts.Services.Command;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Accounts.Models;

namespace Accounts.Controllers
{
    public class AccountsController : Controller
    {
        /* public IActionResult FiscalPeriods()
         {
             return View();
         }*/
        private readonly IFiscalPeriods _fiscalperiodRepository;
        private readonly IFiscalPeriodCommands _fiscalperiodCommands;
        private readonly IMapper _mapper;

        public AccountsController(
            IFiscalPeriods fiscalPeriodsRepository, 
            IMapper mapper, 
            IFiscalPeriodCommands fiscalperiodCommands)
        {
            _fiscalperiodRepository = fiscalPeriodsRepository;
            _mapper = mapper;
            _fiscalperiodCommands = fiscalperiodCommands;
        }
        public async Task<IActionResult> FiscalPeriods()
        {
            var items = await _fiscalperiodRepository.GetFiscalPeriods();

            FiscalPeriodVM inventoryItems = new FiscalPeriodVM()
            {
                FiscalPeriodsList = items,
            };
            return View(inventoryItems);

            /*return NotFound();*/
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FiscalPeriods(FiscalPeriodVM fiscaldetails)
        {
            var fiscalPeriodId = _mapper.Map<FiscalPeriod>(fiscaldetails);
            _fiscalperiodCommands.AddFiscalPeriod(fiscalPeriodId);
            _fiscalperiodCommands.SaveChanges();
            return RedirectToAction(nameof(FiscalPeriods));
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
