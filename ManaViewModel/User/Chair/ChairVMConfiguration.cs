using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.User.Chair
{
    public class ChairVMConfiguration : BaseVM<ChairVM, Entities.User.Chair.Chair, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.Chair.Chair, ChairVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}
