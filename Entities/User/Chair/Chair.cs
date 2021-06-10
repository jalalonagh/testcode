using Entities.Common;
using System.Collections.Generic;

namespace Entities.User.Chair
{
    public class Chair : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<ChairToUser.ChairToUser> ChairToUsers { get; set; }
    }
}
