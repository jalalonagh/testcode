using ManaViewModel.Common;

namespace ManaViewModel.User.Role
{
    public class RoleVM : BaseInterfaceVM<RoleVM, Entities.User.Role.Role, int>
    {
        public string Description { get; set; }
    }
}
