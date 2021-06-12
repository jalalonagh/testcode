using ManaAutoMapper.Interfaces;
using ManaEnums.Entity.User;
using ManaViewModel.Common;
using System;
using System.Collections.Generic;

namespace ManaViewModel.User
{
    public class UserVM : BaseInterfaceVM<UserVM, Entities.User.User, int>, IHaveCustomMapping
    {
        public string UserType { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public UserGenderType Gender { get; set; }
        public int? SaleCustomerSi { get; set; }
        public string SaleCustomerCu { get; set; }
        public string SaleCustomerTp { get; set; }
        public string Avatar { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string NikName { get; set; }
        public bool IsPerson { get; set; }

        public IEnumerable<ChairToUser.ChairToUserVM> Chairs { get; set; }
    }
}