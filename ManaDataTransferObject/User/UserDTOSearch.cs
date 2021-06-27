using ManaDataTransferObject.Common;
using ManaEnums.Entity.User;
using System;

namespace ManaDataTransferObject.User
{
    public class UserDTOSearch : BaseSearchDTO<UserDTOSearch, Entities.User.UserSearch, int>
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public UserGenderType? Gender { get; set; }
        public int? SalcustSi { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string NikName { get; set; }
        public bool? IsPerson { get; set; }
        public int? AccountingUserReferenceId { get; set; }
    }
}