using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.User.Chair
{
    public class Chair: BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<ChairToUser.ChairToUser> ChairToUsers { get; set; }
    }
}
