using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Profile.PhoneNumberType
{
    internal class PhoneNumberTypeVMConfiguration : BaseVM<PhoneNumberTypeVM, Entities.Profile.PhoneNumberType.PhoneNumberType, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.PhoneNumberType.PhoneNumberType, PhoneNumberTypeVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}