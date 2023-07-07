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
            AccountDetail accountDetails = await _generalLedgerAccountsQuery.GetAccountDetails(accountID);            
            ReadAccountDetailsDto readAccountDetails = _mapper.Map<ReadAccountDetailsDto>(accountDetails);
            return Json(readAccountDetails);                    

        }
        public async Task<JsonResult> DeleteAccount([FromBody] int accountID) 
        {

            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteAccount(accountID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { status = true, responce = "Account deleted successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Cannot delete the account because it has associated sub-accounts." });
            }
        }
        public async Task<JsonResult> GetAllLedgerAccountsPanelSubAccountsByAccountID([FromBody]int accountID)
        {
            /*if (accountID <= 0)
            {
                return Json(new { message = "Invalid account ID." });
               
            }*/            
            IEnumerable<SubAccountDetail> accountSubAccounts = await _generalLedgerAccountsQuery.GetAllSubAccountsByAccountID(accountID);
            IEnumerable<ReadSubAccountDetailsDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadSubAccountDetailsDto>>(accountSubAccounts);
            return Json(readAccountDetailsDto);
        }
        public async Task<IActionResult> GetSubAccountDetails([FromBody] int subAccountID)
        {
            SubAccountDetail subAccountDetails = await _generalLedgerAccountsQuery.GetSubAccountDetails(subAccountID);
            ReadSubAccountDetailsDto readAccountDetails = _mapper.Map<ReadSubAccountDetailsDto>(subAccountDetails);
            return Json(readAccountDetails);
        }
        public IActionResult ActivateSubAccount()
        {
            return View();
        } 
        public IActionResult DeactivateSubAccount()
        {
            return View();
        }
       /* public IActionResult DeleteSubAccount([FromBody] int subAccountID)
        {
            _generalLedgerAccountsCommand.DeleteSubAccount(subAccountID);
            _generalLedgerAccountsCommand.SaveChanges();
             return Ok();
        }*/

        public async Task<JsonResult> DeleteSubAccount([FromBody] int subAccountID)
        {
           /* _generalLedgerAccountsCommand.DeleteSubAccount(subAccountID);
            _generalLedgerAccountsCommand.SaveChanges();
            return Ok();*/

            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteAccount(subAccountID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { status = true, responce = "Account deleted successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Cannot delete the account because it has associated sub-accounts." });
            }
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
