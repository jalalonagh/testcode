using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Phone
{
    internal class PhoneVMConfiguration : BaseVM<PhoneVM, Entities.Phone.Phone, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Phone.Phone, PhoneVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}