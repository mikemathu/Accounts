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
            CreateMap<ReadAllAccountsDto, AccountDetail>().ReverseMap();
            //CreateMap<AccountDetail, ReadAccountDetailsListDto>().ReverseMap();
            CreateMap<CreateUpdateAccountDto, AccountDetail>();
            CreateMap<CashFlowCategory, ReadCashFlowCategoryDto>().ReverseMap();
            CreateMap<CreateUpdateSubAccountDto, SubAccountDetail>().ReverseMap();
            CreateMap<CreateUpdateCashFlowCategoryDto, CashFlowCategory>().ReverseMap();
        }
    }
}