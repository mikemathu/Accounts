namespace Accounts.Dtos
{
    public class ReadSubAccountDetailsDto
    {
        public int AccountID { get; set; }
        public int CurrentBalance { get; set; }
        public string Name { get; set; }
        public int SubAccountID { get; set; }
    }
}
