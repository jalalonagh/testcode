using ManaEnums.Entity.User;
using ManaViewModel.Common;
using System;
using System.Collections.Generic;

namespace ManaViewModel.User
{
    public class UserVM : BaseInterfaceVM<UserVM, Entities.User.User, int>
    {
        public string UserType { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public UserGenderType Gender { get; set; }
        public int? SalcustSi { get; set; }
        public string SalcustCu { get; set; }
        public string SalcustTp { get; set; }
        public string Avatar { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string NikName { get; set; }
        public string ValidCode { get; set; }
        public DateTime ValidCodeExpired { get; set; }
        public bool IsPerson { get; set; }
        public int? AccountingUserReferenceId { get; set; }

        public IEnumerable<ChairToUser.ChairToUserVM> Chairs { get; set; }
    }
}