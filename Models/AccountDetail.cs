using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class AccountDetail
    {
        [Key]
        public int AccountID { get; set; }
        public int AccountNo { get; set; }

        [ForeignKey("AccountClassID")]
        public AccountClass AccountClass { get; set; }
        public int AccountClassID { get; set; }

        [ForeignKey("CashFlowCategoryID")]
        public CashFlowCategory CashFlowCategory { get; set; }
        public int CashFlowCategoryID { get; set; }

        [ForeignKey("ConfigurationType")]
        public Configuration Configuration { get; set; }
        public int ConfigurationType { get; set; }

        public int IsLocked { get; set; }
        public string AccountName { get; set; }
    }
}
