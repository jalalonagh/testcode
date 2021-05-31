using ManaViewModel.Common;
using System.Collections.Generic;

namespace ManaViewModel.User.Chair
{
    public class ChairVM : BaseVM<ChairVM, Entities.User.Chair.Chair, int>
    {
        public string Name { get; set; }
        public IEnumerable<ChairToUser.ChairToUserVM> ChairToUsers { get; set; }
    }
}
