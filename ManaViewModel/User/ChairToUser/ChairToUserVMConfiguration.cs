using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.User.ChairToUser
{
    public class ChairToUserVMConfiguration : BaseVM<ChairToUserVM, Entities.User.ChairToUser.ChairToUser, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.ChairToUser.ChairToUser, ChairToUserVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}
