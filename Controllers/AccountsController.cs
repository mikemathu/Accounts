using Accounts.Dtos;
using Accounts.Models;
using Accounts.Models.VM;
using Accounts.Services;
using Accounts.Services.Command;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
            IEnumerable<AccountDetail> accounts = await _generalLedgerAccountsQuery.GetAllAccounts();
            IEnumerable<ReadAllAccountsDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadAllAccountsDto>>(accounts);
            return Json(readAccountDetailsDto);
        }

        [HttpPost]
        public async Task<IActionResult> GetAccountDetails([FromBody] int accountID)
        {
            try
            {   
                AccountDetail accountDetails = await _generalLedgerAccountsQuery.GetAccountDetails(accountID);

                if (accountDetails != null)
                {
                    ReadAccountDetailsDto readAccountDetails = _mapper.Map<ReadAccountDetailsDto>(accountDetails);
                    return Json(readAccountDetails);
                }
                else
                {
                    return Json(null); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving account details.");
            }


        }
        public IActionResult DeleteAccount([FromBody] int accountID) 
        {
            _generalLedgerAccountsCommand.DeleteAccount(accountID);
            _generalLedgerAccountsCommand.SaveChanges();
            return Ok();
    }
        public async Task<JsonResult> GetAllLedgerAccountsPanelSubAccountsByAccountID([FromBody]int accountID)
        {
            var accountSunAccounts= await  _generalLedgerAccountsQuery.GetAllSubAccountsByAccountID(accountID);

            return Json(accountSunAccounts);
        }
        public async Task<IActionResult> GetSubAccountDetails([FromBody] int subAccountID)
        {
            var subAccountDetails = await _generalLedgerAccountsQuery.GetSubAccountDetails(subAccountID);

            //var readAccountDetails = _mapper.Map<ReadAccountDetailsDto>(accountDetails);
            return Json(subAccountDetails);
        }
        public IActionResult ActivateSubAccount()
        {
            return View();
        } 
        public IActionResult DeactivateSubAccount()
        {
            return View();
        }
        public IActionResult DeleteSubAccount([FromBody] int subAccountID)
        {
            _generalLedgerAccountsCommand.DeleteSubAccount(subAccountID);
            _generalLedgerAccountsCommand.SaveChanges();
             return Ok();
        }
        public async Task<JsonResult> GetActiveCashFlowCategories()
        {
            var cashFlowCategories = await _generalLedgerAccountsQuery.GetActiveCashFlowCategories();
           // ReadCashFlowCategoryDto readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategories);

            //return Json(readCashFlowCategoryDto);
            return Json(cashFlowCategories);
        }
        public async Task<JsonResult> GetAllAccountClasses()
        {
            var accountClasses = await _generalLedgerAccountsQuery.GetAllAccountClasses();
           
            return Json(accountClasses);
        }
        public async Task<IActionResult> GetCashFlowCategoryDetails([FromBody] int cashFlowCategoryID)
        {
            var cashFlowCategoryDetails = await _generalLedgerAccountsQuery.GetCashFlowCategoryDetails(cashFlowCategoryID);

            //var readAccountDetails = _mapper.Map<ReadAccountDetailsDto>(accountDetails);
            return Json(cashFlowCategoryDetails);
        } 
        public IActionResult DeleteCashFlowCategory([FromBody] int cashFlowCategoryID)
        {
            _generalLedgerAccountsCommand.DeleteCashFlowCategory(cashFlowCategoryID);
            _generalLedgerAccountsCommand.SaveChanges();
            return Ok();
        }

        [HttpPost]      
        //public JsonResult CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        public async  Task<JsonResult> CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        {
            var accountModel = _mapper.Map<AccountDetail>(createUpdateAccountDto);
            _generalLedgerAccountsCommand.CreateUpdateAccount(accountModel);
            _generalLedgerAccountsCommand.SaveChanges();

            var readAccountDetailsDto = _mapper.Map<ReadAccountDetailsDto>(accountModel);
            return Json(readAccountDetailsDto);
        }
        public async Task<JsonResult> CreateAccountClass([FromBody] CreateAccountClassDto createAccountClassDto)
        {
            var accountClassModel = _mapper.Map<AccountClass>(createAccountClassDto);
            _generalLedgerAccountsCommand.CreateAccountClass(accountClassModel);
            _generalLedgerAccountsCommand.SaveChanges();

            var readAccountDetailsDto = _mapper.Map<ReadAccountClassDto>(accountClassModel);
            return Json(readAccountDetailsDto);
        }
        public async Task<JsonResult> CreateUpdateSubAccount([FromBody] CreateUpdateSubAccountDto createUpdateSubAccountDto)
        {
            var subAccountModel = _mapper.Map<SubAccountDetail>(createUpdateSubAccountDto);
            _generalLedgerAccountsCommand.CreateUpdateSubAccount(subAccountModel);
            _generalLedgerAccountsCommand.SaveChanges();

            var readAccountDetailsDto = _mapper.Map<ReadSubAccountDetailsDto>(subAccountModel);
            return Json(readAccountDetailsDto);
        }
        public IActionResult CreateUpdateCashFlowCategory([FromBody] CreateUpdateCashFlowCategoryDto createUpdateCashFlowCategoryDto)
        {
            var cashFlowCategory = _mapper.Map<CashFlowCategory>(createUpdateCashFlowCategoryDto);
            _generalLedgerAccountsCommand.CreateUpdateCashFlowCategory(cashFlowCategory);
            _generalLedgerAccountsCommand.SaveChanges();

            var readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategory);
            return Json(readCashFlowCategoryDto);
        }


    }
}
