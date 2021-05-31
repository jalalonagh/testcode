using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Profile.PhoneNumber
{
    internal class PhoneNumberVMConfiguration : BaseVM<PhoneNumberVM, Entities.Profile.PhoneNumber.PhoneNumber, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.PhoneNumber.PhoneNumber, PhoneNumberVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}