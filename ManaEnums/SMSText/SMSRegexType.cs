using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaEnums.SMSText
{
    public enum SMSRegexType
    {
        [Display(Name = "واریز بانکی")]
        BANK_DEPOSIT = 0,
        [Display(Name = "برداشت بانکی")]
        BANK_WITHDRAWAL = 1
    }
}
