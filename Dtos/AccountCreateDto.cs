namespace Accounts.Dtos
{
    public class CreateUpdateAccountDto
    {
        public int AccountClass { get; set; }
        public string Name { get; set; }
        public int CashFlowCategoryID { get; set; }
    }
}
