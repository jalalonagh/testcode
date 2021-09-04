using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.User
{
    internal class UserVMConfiguration : BaseInterfaceVM<UserVM, Entities.User.User, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.User, UserVM> mapping)
        {

        }
    }
}
