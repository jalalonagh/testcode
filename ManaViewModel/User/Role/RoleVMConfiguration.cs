using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.User.Role
{
    public class RoleVMConfiguration : BaseInterfaceVM<RoleVM, Entities.User.Role.Role, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.Role.Role, RoleVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}
