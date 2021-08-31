using System.ComponentModel.DataAnnotations;

namespace ManaEnums.Api
{
    public enum ApiResultStatus
    {
        [Display(Name = "عملیات با موفقیت انجام شد.")]
        SUCCESS = 200,
        [Display(Name = "خطایی در سرور رخ داده است")]
        SERVER_ERROR = 500,
        [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
        BAD_REQUEST = 400,
        [Display(Name = "یافت نشد")]
        NOT_FOUND = 404,
        [Display(Name = "لیست خالی است")]
        LIST_EMPTY = 204,
        [Display(Name = "خطایی در پردازش رخ داد")]
        LOGIC_ERROR = 409,
        [Display(Name = "خطای احراز هویت")]
        UNAUTHORIZED = 403,
        [Display(Name = "محدودیت فروش")]
        SALE_LIMITATION = 210
    }
}