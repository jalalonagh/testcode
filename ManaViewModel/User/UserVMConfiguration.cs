using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.User
{
    public class UserVMConfiguration : BaseInterfaceVM<UserVM, Entities.User.User, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.User, UserVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}