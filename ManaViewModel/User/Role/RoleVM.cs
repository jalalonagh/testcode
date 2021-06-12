using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;

namespace ManaViewModel.User.Role
{
    public class RoleVM : BaseInterfaceVM<RoleVM, Entities.User.Role.Role, int>, IHaveCustomMapping
    {
        public string Description { get; set; }
    }
}
