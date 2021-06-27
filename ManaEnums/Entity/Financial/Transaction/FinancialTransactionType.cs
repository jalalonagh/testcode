using System.ComponentModel.DataAnnotations;

namespace ManaEnums.Entity.Financial.Transaction
{
    public enum FinancialTransactionType
    {
        [Display(Name = "واریز")]
        DEPOSIT = 1,
        [Display(Name = "برداشت")]
        WITHDRAWAL = -1
    }
}
