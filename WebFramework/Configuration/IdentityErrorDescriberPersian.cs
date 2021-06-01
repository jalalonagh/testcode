using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebFramework.Configuration
{
   public class IdentityErrorDescriberPersian:IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            //return base.DuplicateEmail(email);
            return new IdentityError
            {
                Code = base.DuplicateEmail(email).Code,
                Description = $"ایمیل {email} قبلا ثبت شده است اگر صاحب این ایمیل هستید به صفحه ورود بروید . در غیر این صورت وارد قسمت فراموشی رمز شوید."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = base.PasswordRequiresLower().Code,
                Description = $"پسورد باید حداقل {length} کاراکتر باشد."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            //return base.PasswordRequiresDigit();
            return new IdentityError
            {
                Code = base.PasswordRequiresDigit().Code,
                Description = $"پسورد باید شامل اعداد باشد"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = base.PasswordRequiresUpper().Code,
                Description = $"پسورد باید شامل حروف بزرگ باشد"
            };
        }
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = base.PasswordRequiresUniqueChars(uniqueChars).Code,
                Description = $"تعداد کاراکتر ها تکراری باید {uniqueChars} باشد."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = base.PasswordRequiresUpper().Code,
                Description = $"پسورد باید شامل حروف بزرگ باشد"
            };
        }
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = base.PasswordMismatch().Code,
                Description = $"پسورد ها وارد شده یکسان نیستند"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {

            return new IdentityError
            {
                Code = base.PasswordRequiresNonAlphanumeric().Code,
                Description = $"پسورد باید شامل حروف نباشد"
            };
 
        }
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = base.InvalidEmail(email).Code,
                Description = $"ایمیل {email} صحیح نمی باشد"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = base.DuplicateUserName(userName).Code,
                Description = $"قبلا این کاربر ثبت نام شده است"
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = base.InvalidUserName(userName).Code,
                Description = $"نام کاربری صحیح نمی باشد"
            };
        }
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = base.DuplicateRoleName(role).Code,
                Description = $"این مجوز قبلا ثبت شده است"
            };
        }
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = base.InvalidRoleName(role).Code,
                Description = $"نام مجوز صحیح نمی باشد"
            };
        }
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = base.UserNotInRole(role).Code,
                Description = "کاربر شامل مجوز نیست"
            };
        }
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = base.UserAlreadyInRole(role).Code,
                Description = "کاربر قبلا این مجوز را گرفته است."
            };
        }
        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = base.InvalidToken().Code,
                Description = "گواهی دریافتی معتبر نمی باشد."
            };
        }
    }
}
