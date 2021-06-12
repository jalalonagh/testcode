using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;
using ManaEnums.Entity.User;
using System;

namespace ManaDataTransferObject.User
{
    public class UserDTO : BaseInterfaceDTO<UserDTO, Entities.User.User, int>, IHaveCustomMapping
    {
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public string UserType { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public UserGenderType Gender { get; set; }
        public int? SSi { get; set; }
        public string SCu { get; set; }
        public string STp { get; set; }
        public string Avatar { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string NikName { get; set; }
        public string ValidCode { get; set; }
        public DateTime ValidCodeExpired { get; set; }
        public bool IsPerson { get; set; }
        public int? AccountingId { get; set; }
    }
}