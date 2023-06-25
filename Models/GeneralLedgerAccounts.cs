namespace Accounts.Models
{
    public class AccountDetail
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountClass { get; set; }
        public string CashFlow { get; set; }
    }
    public class SubAccountDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive{ get; set; }
        public int AccountDetailsId { get; set; }
        public int CurrentBalance{ get; set; }
    }
}
