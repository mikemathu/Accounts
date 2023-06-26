using Accounts.Models;
using Accounts.Models.VM;
using AutoMapper;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<FiscalPeriodVM, FiscalPeriod>();
        }
    }
}