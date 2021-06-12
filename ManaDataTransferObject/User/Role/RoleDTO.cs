using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.Role
{
    public class RoleDTO : BaseInterfaceDTO<RoleDTO, Entities.User.Role.Role, int>, IHaveCustomMapping
    {
        public string Description { get; set; }
    }
}
