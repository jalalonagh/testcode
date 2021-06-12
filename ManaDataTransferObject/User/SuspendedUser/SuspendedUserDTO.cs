using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;
using ManaEnums.Entity.User;
using System;

namespace ManaDataTransferObject.User.SuspendedUser
{
    public class SuspendedUserDTO : BaseDTO<SuspendedUserDTO, Entities.User.SuspendedUser.SuspendedUser, int>, IHaveCustomMapping
    {
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmated { get; set; }
        public string ValidCode { get; set; }
        public DateTime ValidCodeExpired { get; set; }
        public SuspendedUserType Type { get; set; }
    }
}
