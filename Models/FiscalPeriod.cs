namespace Accounts.Models
{
    public class FiscalPeriod
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int IsActive { get; set; }
        public int IsOpen { get; set; }
    }
}
