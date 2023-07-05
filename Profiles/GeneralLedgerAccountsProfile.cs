using Accounts.Dtos;
using Accounts.Models;
using Accounts.Models.VM;
using AutoMapper;

namespace PlatformService.Profiles
{
    public class GeneralLedgerAccountsProfile : Profile
    {
        public GeneralLedgerAccountsProfile()
        {
            // Source -> Target
            CreateMap<FiscalPeriodVM, FiscalPeriod>();
            CreateMap<AccountDetailVM, AccountDetail>();

            //GeneralLedgerAccounts
            CreateMap<ReadAccountDetailsDto, AccountDetail>().ReverseMap();
            //CreateMap<AccountDetail, ReadAccountDetailsDto>();
            CreateMap<CreateUpdateAccountDto, AccountDetail>();
            CreateMap<CashFlowCategory, ReadCashFlowCategoryDto>().ReverseMap();
        }
    }
}