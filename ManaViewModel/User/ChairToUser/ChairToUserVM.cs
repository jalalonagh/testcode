using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;
using System;

namespace ManaViewModel.User.ChairToUser
{
    public class ChairToUserVM : BaseVM<ChairToUserVM, Entities.User.ChairToUser.ChairToUser, int>, IHaveCustomMapping
    {
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public int ChairId { get; set; }
        public Chair.ChairVM Chair { get; set; }
        public DateTime DateDm { get; set; }
        public string DateDs { get; set; }
    }
}
