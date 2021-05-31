//using Entities.User;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using ViewModels.Sale;

//namespace BusinessLayout.User
//{
//    public class UserVM2
//    {
//        public string UserType { get; set; }
//        public DateTime CreateDm { get; set; }
//        public string CreateDs { get; set; }
//        public DateTime? LastUpdateDm { get; set; }
//        public string LastUpdateDs { get; set; }
//        [Required]
//        [StringLength(100)]
//        public string FullName { get; set; }
//        public int Age { get; set; }
//        public GenderType Gender { get; set; }
//        public bool IsActive { get; set; }
//        public int? SalcustSi { get; set; }
//        public string SalcustCu { get; set; }
//        public string SalcustTp { get; set; }
//        public string Avatar { get; set; }
//        public DateTimeOffset? LastLoginDate { get; set; }
//        public string NikName { get; set; }
//        public IEnumerable<ContactVM> Contacts { get; set; }
//        public string ValidCode { get; set; }
//        public bool IsPerson { get; set; }
//        public DateTime ValidCodeExpired { get; set; }

//        public static implicit operator UserVM2(Entities.User.User user)
//        {
//            return new UserVM2
//            {
//                Age = user.Age,
//                Avatar = user.Avatar,
//                Contacts = (user.Contacts != null) ? (user.Contacts.Select(z => ContactVM.FromEntity(z))) : null,
//                CreateDm = user.CreateDm,
//                CreateDs = user.CreateDs,
//                FullName = user.FullName,
//                Gender = user.Gender,
//                IsActive = user.IsActive,
//                LastLoginDate = user.LastLoginDate,
//                LastUpdateDm = user.LastUpdateDm,
//                LastUpdateDs = user.LastUpdateDs,
//                NikName = user.NikName,
//                SalcustCu = user.SalcustCu,
//                SalcustSi = user.SalcustSi,
//                SalcustTp = user.SalcustTp,
//                ValidCode = user.ValidCode,
//                IsPerson = user.IsPerson,
//                ValidCodeExpired = user.ValidCodeExpired,
//                UserType = user.UserType
//            };
//        }
//    }

//}
