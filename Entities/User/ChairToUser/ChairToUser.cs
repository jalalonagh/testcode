using ManaBaseEntity.Common;
using System;

namespace Entities.User.ChairToUser
{
    public class ChairToUser : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChairId { get; set; }
        public Chair.Chair Chair { get; set; }
        public DateTime DateDm { get; set; }
        public string DateDs { get; set; }
    }
}
