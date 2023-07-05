using Accounts.Dtos;
using Accounts.Models;
using Accounts.Services;
using Accounts.Services.Command;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Accounts.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IFiscalPeriods _fiscalperiodRepository;

        private readonly IGeneralLedgerAccountsCommand _generalLedgerAccountsCommand;
        private readonly IGeneralLedgerAccountsQuery _generalLedgerAccountsQuery;
        private readonly IMapper _mapper;

        public AccountsController(
             IFiscalPeriods fiscalPeriodsRepository,
             IGeneralLedgerAccountsQuery accounts,
             IGeneralLedgerAccountsCommand generalLedgerAccountsCommand,
            IMapper mapper)
        {
            _fiscalperiodRepository = fiscalPeriodsRepository;
            _generalLedgerAccountsQuery = accounts;
            _mapper = mapper;
            _generalLedgerAccountsCommand = generalLedgerAccountsCommand;
        }
        /// <summary>
        /// GeneralLedgerAccounts
        /// </summary>
        /// <returns></returns>
        public IActionResult GeneralLedgerAccounts()
        {
            return View();
        } 
        public async Task<JsonResult> GetAllAccounts()
        {
            var accounts =  await _generalLedgerAccountsQuery.GetAllAccounts();
            return Json(accounts);
        }

       /* public async Task<JsonResult> GetAllAccounts2()

        {
            var items = await _fiscalperiodRepository.GetAccountsDetails();
            return Json(items);
        }*/
        public IActionResult GetAccountDetails()
        {
            return View();
        }
        public IActionResult DeleteAccount()
        {
            return View();
        }
        public IActionResult GetAllLedgerAccountsPanelSubAccountsByAccountID()
        {
            return View();
        }
        public IActionResult GetSubAccountDetails()
        {
            return View();
        }
        public IActionResult ActivateSubAccount()
        {
            return View();
        } 
        public IActionResult DeactivateSubAccount()
        {
            return View();
        }
        public IActionResult DeleteSubAccount()
        {
            return View();
        }
        public IActionResult GetActiveCashFlowCategories()
        {
            return View();
        }
        public IActionResult GetCashFlowCategoryDetails()
        {
            return View();
        } 
        public IActionResult DeleteCashFlowCategory()
        {
            return View();
        }

        [HttpPost]      
        public JsonResult CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        {
            var accountModel = _mapper.Map<AccountDetail>(createUpdateAccountDto);
            _generalLedgerAccountsCommand.CreateUpdateAccount(accountModel);
            _generalLedgerAccountsCommand.SaveChanges();

            var readAccountDto = _mapper.Map<ReadAccountDto>(accountModel);
            return Json(readAccountDto);
        }
        public IActionResult CreateUpdateSubAccount()
        {
         
            return View();
        }
        public IActionResult CreateUpdateCashFlowCategory()
        {
            return View();
        }


    }
}
