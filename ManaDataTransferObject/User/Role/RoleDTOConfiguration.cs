using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.Role
{
    public class RoleDTOConfiguration : BaseInterfaceDTO<RoleDTO, Entities.User.Role.Role, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.Role.Role, RoleDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}
