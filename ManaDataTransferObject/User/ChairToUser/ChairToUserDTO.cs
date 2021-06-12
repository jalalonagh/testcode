using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;
using System;

namespace ManaDataTransferObject.User.ChairToUser
{
    public class ChairToUserDTO : BaseDTO<ChairToUserDTO, Entities.User.ChairToUser.ChairToUser, int>, IHaveCustomMapping
    {
        public int UserId { get; set; }
        public int ChairId { get; set; }
        public DateTime DateDm { get; set; }
        public string DateDs { get; set; }
    }
}
