namespace Accounts.Models.VM
{
    public class FiscalPeriodVM
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int IsActive { get; set; }
        public int IsOpen { get; set; }
    }

    public class FiscalPeriodVMList
    {
        public IEnumerable<FiscalPeriodVM> FiscalPeriodsList { get; set; }
    }
}
