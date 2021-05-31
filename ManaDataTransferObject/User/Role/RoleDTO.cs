using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.Role
{
    public class RoleDTO : BaseInterfaceDTO<RoleDTO, Entities.User.Role.Role, int>
    {
        public string Description { get; set; }
    }
}
