using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;
using System;

namespace ManaViewModel.User.SuspendedUser
{
    public class SuspendedUserVM : BaseVM<SuspendedUserVM, Entities.User.SuspendedUser.SuspendedUser, int>, IHaveCustomMapping
    {
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmated { get; set; }
        public string ValidCode { get; set; }
        public DateTime ValidCodeExpired { get; set; }
        public int Type { get; set; }
    }
}
