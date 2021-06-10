using Entities.Common;
using ManaEnums.Entity.User;
using System;

namespace Entities.User.SuspendedUser
{
    public class SuspendedUser : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmated { get; set; }
        public string ValidCode { get; set; }
        public DateTime ValidCodeExpired { get; set; }
        public SuspendedUserType Type { get; set; }
    }
}
