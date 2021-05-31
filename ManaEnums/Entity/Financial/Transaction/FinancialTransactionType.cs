using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
