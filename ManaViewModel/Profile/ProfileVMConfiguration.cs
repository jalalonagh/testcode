using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Profile
{
    internal class ProfileVMConfiguration : BaseVM<ProfileVM, Entities.Profile.Profile, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.Profile, ProfileVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}