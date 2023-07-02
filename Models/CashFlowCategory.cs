using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class CashFlowCategory
    {
        [Key]
        public int CashFlowCategoryID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        //public int IsActive { get; set; } //confirm whether it is possible to activate or deactivate
    }
}
