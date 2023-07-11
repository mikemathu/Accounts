﻿using Accounts.Dtos;
using Accounts.Models;
using Accounts.Models.VM;
using Accounts.Services;
using Accounts.Services.Command;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Net;

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
        public async Task<JsonResult> DeleteSubAccount([FromBody] int subAccountID)
        {

            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteSubAccount(subAccountID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.OK } );
            }
            else
            {
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.Conflict, responce = "Cannot delete the Sub Account because it has a Balance. Consider Transfering the balance." });
            }
        }
        public async Task<JsonResult> GetActiveCashFlowCategories()
        {

            IEnumerable<CashFlowCategory> cashFlowCategories = await _generalLedgerAccountsQuery.GetActiveCashFlowCategories();
            IEnumerable<ReadCashFlowCategoryDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadCashFlowCategoryDto>>(cashFlowCategories);

            return Json(readAccountDetailsDto);
        }
        public async Task<JsonResult> GetAllAccountClasses()
        {
            IEnumerable<AccountClass> accountClasses = await _generalLedgerAccountsQuery.GetAllAccountClasses();
            IEnumerable<ReadAccountClassDto2> readAccountClassDto = _mapper.Map<IEnumerable<ReadAccountClassDto2>>(accountClasses);

            return Json(accountClasses);
        }
        public async Task<IActionResult> GetCashFlowCategoryDetails([FromBody] int cashFlowCategoryID)
        {
            CashFlowCategory cashFlowCategoryDetails = await _generalLedgerAccountsQuery.GetCashFlowCategoryDetails(cashFlowCategoryID);
            ReadCashFlowCategoryDto readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategoryDetails);
            return Json(readCashFlowCategoryDto);
        } 
        public async Task<JsonResult> DeleteCashFlowCategory([FromBody] int cashFlowCategoryID)
        {
            /*   _generalLedgerAccountsCommand.DeleteCashFlowCategory(cashFlowCategoryID);
               _generalLedgerAccountsCommand.SaveChanges();
               return Ok();*/


            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteCashFlowCategory(cashFlowCategoryID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.OK });
            }
            else
            {
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.Conflict, responce = "Cannot delete the Sub Account because it has a Balance. Consider Transfering the balance." });
            }

        }

        [HttpPost]      
        //public JsonResult CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        public async  Task<JsonResult> CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        {
            AccountDetail accountModel = _mapper.Map<AccountDetail>(createUpdateAccountDto);

            bool createUpdateAccount = _generalLedgerAccountsCommand.CreateUpdateAccount(accountModel);


            if (createUpdateAccount)
            {
                _generalLedgerAccountsCommand.SaveChanges();

                AccountDetail accountDetails = await _generalLedgerAccountsQuery.GetAccountClassName(accountModel);

                CreateUpdateAccountReadDto readAccountDetailsDto = _mapper.Map<CreateUpdateAccountReadDto>(accountDetails);
               return Json( readAccountDetailsDto );
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account" });
            }
        }
        public async Task<JsonResult> CreateAccountClass([FromBody] CreateAccountClassDto createAccountClassDto)
        {
            AccountClass accountClassModel = _mapper.Map<AccountClass>(createAccountClassDto);
            /*_generalLedgerAccountsCommand.CreateAccountClass(accountClassModel);
            _generalLedgerAccountsCommand.SaveChanges();

            ReadAccountClassDto readAccountDetailsDto = _mapper.Map<ReadAccountClassDto>(accountClassModel);
            return Json(readAccountDetailsDto);*/


            ///
            bool createAccountClass = _generalLedgerAccountsCommand.CreateAccountClass(accountClassModel);


            if (createAccountClass)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                ReadAccountClassDto readAccountDetailsDto = _mapper.Map<ReadAccountClassDto>(accountClassModel);
                return Json(new { readAccountDetailsDto, status = true, responce = "Account Created successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account class" });
            }
        }
        public async Task<JsonResult> CreateUpdateSubAccount([FromBody] CreateUpdateSubAccountDto createUpdateSubAccountDto)
        {
            var subAccountModel = _mapper.Map<SubAccountDetail>(createUpdateSubAccountDto);
     /*       _generalLedgerAccountsCommand.CreateUpdateSubAccount(subAccountModel);
            _generalLedgerAccountsCommand.SaveChanges();

            var readAccountDetailsDto = _mapper.Map<ReadSubAccountDetailsDto>(subAccountModel);
            return Json(readAccountDetailsDto);*/

            //
            bool createUpdateSubAccount = _generalLedgerAccountsCommand.CreateUpdateSubAccount(subAccountModel);


            if (createUpdateSubAccount)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                ReadSubAccountDetailsDto readAccountDetailsDto = _mapper.Map<ReadSubAccountDetailsDto>(subAccountModel);
                return Json(new { readAccountDetailsDto, status = true, responce = "Sub Account Created successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account class" });
            }
        }
        public IActionResult CreateUpdateCashFlowCategory([FromBody] CreateUpdateCashFlowCategoryDto createUpdateCashFlowCategoryDto)
        {
            var cashFlowCategory = _mapper.Map<CashFlowCategory>(createUpdateCashFlowCategoryDto);
      /*      _generalLedgerAccountsCommand.CreateUpdateCashFlowCategory(cashFlowCategory);
            _generalLedgerAccountsCommand.SaveChanges();

            var readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategory);
            return Json(readCashFlowCategoryDto);*/

            //

            bool createUpdateSubAccount = _generalLedgerAccountsCommand.CreateUpdateCashFlowCategory(cashFlowCategory);


            if (createUpdateSubAccount)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                ReadCashFlowCategoryDto readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategory);
                return Json(new { readCashFlowCategoryDto, status = true, responce = "Sub Account Created successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account class" });
            }
        }



        /// <summary>
        /// PaymentModes
        /// </summary>
        /// <returns></returns>


        public IActionResult PaymentModes()
        {
            return View();
        }

        public async Task<IActionResult> GetPaymentModes()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> GetPaymentModeDetails([FromBody] int paymentModeID)
        {
            PaymentMode paymentModelDetails = await _generalLedgerAccountsQuery.GetPaymentModeDetails(paymentModeID);
            ReadPaymentModelDetailsDto readPaymentModelDetailsDto = _mapper.Map<ReadPaymentModelDetailsDto>(paymentModelDetails);
            return Json(readPaymentModelDetailsDto);
        }

        public IActionResult DeletePaymentMode([FromBody] int paymentModeID)
        {

            bool IsPaymentModeDeleted = _generalLedgerAccountsCommand.DeletePaymentMode(paymentModeID);

            if (IsPaymentModeDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.OK });
            }
            else
            {
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.Conflict, responce = "Cannot delete the Sub Account because it has a Balance. Consider Transfering the balance." });
            }
        }

        public IActionResult GetBankAndCashSubAccounts()
        {
            return View();
        }
        public IActionResult GetAllPaymentModeCategories()
        {
            return View();
        }
        public IActionResult GetPaymentModeSelectionLevels()
        {
            return View();
        }
        public IActionResult GetPaymentModeSelectionLevelsByLevel()
        {
            return View();
        }
        public IActionResult GetPaymentModeSelectionLevelDetails()
        {
            return View();
        }
        public IActionResult DeletePaymentModeSelectionLevel()
        {
            return View();
        }
        public IActionResult GetInnerMostPaymentModeSelectionLevels()
        {
            return View();
        }
    }
}
