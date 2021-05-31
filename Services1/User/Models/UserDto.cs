using Entities;
using Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Sale
{



    [Serializable]
    public class UserDto
    {
        public string UserType { get; set; }
        public int Id { get; set; }
        //[Required(ErrorMessage = "نام کاربری خود را لطفا وارد نمائید")]
        [StringLength(100)]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "ایمیل خود را لطفا وارد نمائید")]
        [StringLength(100)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "رمز عبور خود را لطفا وارد نمائید")]
        [StringLength(500)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "نام و نام خانوادگی خود را لطفا وارد نمائید")]
        [StringLength(100)]
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public string NikName { get; set; }
        public IEnumerable<ContactEdite> Contacts { get; set; }
        public bool IsPerson { get; set; }
        public string SalcustTp { get; set; }
        public string SalcustCu { get; set; }
        public int? SalcustSi { get; set; }
    }

    public class UserPasswordResertDTO
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }

    [Serializable]
    public class UserEditDto
    {
        public string UserName { get; set; }
        public string UserType { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public string NikName { get; set; }
        public bool IsPerson { get; set; }
        public IEnumerable<ContactEdite> Contacts { get; set; }
    }
    public class ContactEdite
    {
        public string Value { get; set; }
        public ContactTypeEnum ContactType_Id { get; set; }
    }


    [Serializable]
    public class UserVerifiedDto// : IValidatableObject
    {
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (UserName.Equals("test", StringComparison.OrdinalIgnoreCase))
        //        yield return new ValidationResult("نام کاربری نمیتواند Test باشد", new[] { nameof(UserName) });
        //}
    }

}