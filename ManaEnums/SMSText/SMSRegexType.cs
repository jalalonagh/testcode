using System.ComponentModel.DataAnnotations;

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
